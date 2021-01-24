    var fakeFixer = A.Fake<IFixer>();
    var manager = new Manager(fakeFixer);
    var product = new Product { Id = 100, Name = "Default" }; // create another test for where Name != "Default"
    var isNew = manager.IsProductNew(product);
    
    // Assert that fixer.modify is called with the product
    A.CallTo(() => fakeFixer.Modify(A<product>.That.Matches(p => p.Id == 100))).ShouldHaveBeenCalledOnceExactly();
    // Should return false because of product name = "Default"
    Assert.IsFalse(isNew);
