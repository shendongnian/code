    using Autofac;
    using Autofac.Extras.Moq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class AutoMockTests {
        [TestMethod]
        public void Should_AutoMock_PropertyInjection() {
            using (var mock = AutoMock.GetLoose(builder => {
                builder.RegisterType<SystemUnderTest>().PropertiesAutowired();
            })) {
                // Arrange
                var expected = "expected value";
                mock.Mock<IDependency>().Setup(x => x.GetValue()).Returns(expected);
                var sut = mock.Create<SystemUnderTest>();
                sut.Dependency.Should().NotBeNull(); //property should be injected
                // Act
                var actual = sut.DoWork();
                // Assert - assert on the mock
                mock.Mock<IDependency>().Verify(x => x.GetValue());
                Assert.AreEqual("expected value", actual);
            }
        }
    }
