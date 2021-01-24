    [TestMethod]
    public void CheckAvailabilityTest() {
        //Act
        var actualQR = barcodeController.CheckAvailability();
        var contentVersion = actualQR as OkNegotiatedContentResult<string>;
        //Assert    
        Assert.IsNotNull(contentVersion); //if null, fail
        Assert.AreNotEqual("", contentVersion.Content); //otherwise check other assertion
    }
