    [TestMethod]
    public async Task ReturnIndexMethod()
    {
        //Arrange
        var controller = new StockController(new FakeStockService());
        
        //Act
        var result = await controller.Index(); 
        
        //Assert
        Assert.IsNotNull(result);
        var view = result as ViewResult;
        Assert.IsNotNull(view);
        var stockResult = view.Model as IEnumerable<StockDto>;
        Assert.IsNotNull(stockResult);
    }
