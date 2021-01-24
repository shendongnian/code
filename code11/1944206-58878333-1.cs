    //Arrange
    var fakeFixer = A.Fake<IFixer>();
     A.CallTo(() => fakeFixer.Func(A<Product>._))
        .Invokes((Product arg) => arg.Name = "Not Default Name");
    var manager = new Manager(fakeFixer);
    
    //Act
    var isNew = manager.IsProductNew(1);
    
    //Assert
    Assert.True(isNew);
