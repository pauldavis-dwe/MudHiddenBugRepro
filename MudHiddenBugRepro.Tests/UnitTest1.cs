using NUnit.Framework;
using Bunit;

namespace MudHiddenBugRepro.Tests
{
    using Moq;
    using System;

    public class Tests : TestContextWrapper, IServiceProvider
    {

        [SetUp]
        public void Setup()
        {
            TestContext = new Bunit.TestContext();
            Services.AddFallbackServiceProvider(this);
        }

        [Test]
        public void Test1()
        {
            RenderComponent<MyComp>();
        }

        public object GetService(Type serviceType)
        {
            var mockType = typeof(Mock<>);
            var serviceMockType = mockType.MakeGenericType(serviceType);
            var mock = (Mock)Activator.CreateInstance(serviceMockType);
            return mock.Object;
        }
    }
}