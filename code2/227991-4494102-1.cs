    [Test]
    public void MyActionIWantToTestReturnsPartialViewResult()
    {
        // Arrange
        const string myTestValue = "Some value";
        var ctrl = new StringController();
    
        // Act
        var result = ctrl.MyActionIWantToTest(myTestValue);
            
        // Assert
        Assert.AreEqual("MyPartialView", result.ViewName);
        Assert.IsInstanceOf<MyPartialViewModel>(result.ViewData.Model);
        Assert.AreEqual(myTestValue, ((MyPartialViewModel)result.ViewData.Model).SomeValue);
    }
