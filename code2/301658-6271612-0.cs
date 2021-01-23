    // Arrange
    IFoo myMock = MockRepository.GenerateMock<IFoo>();
    List<Entity> col = new List<Entity>();
    Entity entity = new Entity();
    
    myMock.Expect(p => p.FooCollection).Return(col);
    // myMock.Expect(p => p.FooCollection.Add(entity)) - skip this
    // Act
    p.YourMethodUnderTest(entity);
    // Assert
    Assert.IsTrue(col.Contains(entity)); // Or something like that
