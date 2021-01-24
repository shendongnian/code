    [TestClass]
    public class SomeClassTests {
        [TestMethod]
        public void DoWork_Should_Be_Done() {
            //Arrange
            IClass1 class1 = Mock.Of<IClass1>();
            Mock<Class2> class2 = new Mock<Class2>();
            class2.Setup(_ => _.Method2(It.IsAny<Action>()))
                .Returns(true)
                .Callback((Action passedAction) => passedAction?.Invoke());
            SomeClass subject = new SomeClass(class1, class2.Object);
            string expected = "done!";
            //Act
            var actual = subject.DoWork();
            //Assert
            actual.Should().Be(expected); //actual == expected
            Mock.Get(class1).Verify(_ => _.Method1(), Times.Once); //was action invoked
        }
    }
