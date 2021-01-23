    [TestClass]
    public class FooTests
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            ItExt.RegisterConvention(() => It.Is<int?>(n => n.HasValue));
        }
        [TestMethod]
        public void FooTest()
        {
            // Arrange
            Mock<IFoo> fooMock = new Mock<IFoo>();
            fooMock.Setup(f => f.Bar(ItExt.IsConventional<int?>()))
                   .Verifiable();
            // Act
            fooMock.Object.Bar(1);
            // Assert
            fooMock.VerifyAll(); // throws
        }
    }
