    public class TestClass {
        [Fact]
        void TestMethod() {
            //Arrange
            object factoryResult = new object(); //The expected result
            var factory = Substitute.For<IFactory>();
            factory.Create().Returns(x => factoryResult); //mocked factory should return this
            IMockable mockable = new Mockable(factory);
    
            //Act
            object mockableResult = mockable.SomeMethod(); //Invoke subject under test
    
            //Assert
            factory.Received(1).Create(); //assert expected behavior
            Assert.Equal(mockableResult, factoryResult); //objects should match
        }
    }
