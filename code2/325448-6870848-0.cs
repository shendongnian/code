    [Test]
    public void testThrowsExceptions()
    {
        // Arrange
        var dependency1 = MockRepository.Mock<IMockFrameworkObject1>();
        var dependency2 = MockRepository.Mock<IMockFrameworkObject2>();
      
        dependency2.Expect(d2 => d2.SomeAction).Throws(new someexception);
    
        var myObject = new ConcreteObject(dependency1, dependency2);
    
        // Act
        myObject.SomeAction();
        
        // Assert
    }
