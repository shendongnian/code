    [Test]
    public void Can_Save_Valid_Changes() {
        //Arrange
        var httpContext = new DefaultHttpContext();
        var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
        var mock = new Mock<IProductRepository>();
        AdminController controller = new AdminController(mock.Object);
        controller.TempData = tempData;
    
        Product product = new Product { Name = "Test"};
    
        //Act
        IActionResult result = controller.Edit(product);
    
        //Assert
        // check if have saved product to repo 
        mock.Verify(m => m.SaveProduct(product));
        Assert.IsNotInstanceOf<ViewResult>(result);
    }
