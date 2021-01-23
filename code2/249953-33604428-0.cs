    [TestMethod]
    public void GetActivationcode_Should_Return_JSON_With_Filled_Model()
    {
        // Arrange...
        ActivatiecodeController activatiecodeController = this.ActivatiecodeControllerFactory();
        CodeModel model = new CodeModel { Activation = "XYZZY", Lifespan = 10000 };
        this.deviceActivatieModelBuilder.Setup(x => x.GenereerNieuweActivatiecode()).Returns(model);
    
        // Act...
        var result = activatiecodeController.GetActivationcode() as JsonResult;
        // Assert...
        ((CodeModel)result.Data).Activation.Should().Be("XYZZY");
        ((CodeModel)result.Data).Lifespan.Should().Be(10000);
    }
