    var fakeProductGetter = A.Fake<IProductGetter>();
    // Prime the product getter to return a product
    A.CallTo(() => fakeProductGetter.Get(A<int>.Ignored))
        .Returns(new Product{
            Id = 100,
            Name = "Default" // create another test for where Name != "Default"
        });
    var fakeFixer = A.Fake<IFixer>();
    var manager = new Manager(fakeFixer, fakeproductGetter);
    var isNew = manager.IsProductNew(100);
    
    // Assert that a call is made to productGetter.Get with the ID
    A.CallTo(() => productGetter.Get(100)).MustHaveHapennedOnceExactly();
    // Assert that fixer.modify is called with the product
    A.CallTo(() => fakeFixer.Modify(A<product>.That.Matches(p => p.Id == 100))).ShouldHaveBeenCalledOnceExactly();
    // Should return false because of product name = "Default"
    Assert.IsFalse(isNew);
