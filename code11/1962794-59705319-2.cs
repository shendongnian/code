	public void ControllerTest()
    {
        //Arrange
        string plainText = "Test123";
        string expected = "HAHAHA 2";
        Mock<IPrimeNumberOperations> _mockService = new Mock<IPrimeNumberOperations>();
        var fakePrimeNumberViewModel = new PrimeNumberViewModel { 
            new Result { removedPrimeNumbersText =  expected} 
        };
        _mockService
            .Setup(x => x.RemovePrimeNumbers(plainText))
            .Returns(fakePrimeNumberViewModel);
		
        var _controller = new PrimeNumberOperationsController(_mockService.Object);
        //Act
        var actual = _controller.RemovePrimeNumbers(plainText);
		
        //Assert
		Assert.AreEqual(expected, actual, "Error message");
    }
