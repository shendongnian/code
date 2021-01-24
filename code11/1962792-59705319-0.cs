	public void ControllerTest()
    {
            Mock<IPrimeNumberOperations> _mockService = new Mock<IPrimeNumberOperations>();
            var fakePrimeNumberViewModel = new PrimeNumberViewModel { new Result { removedPrimeNumbersText =  "HAHAHA 2"} };
            _mockService.Setup(x => x.RemovePrimeNumbers("Test123")).Returns(fakePrimeNumberViewModel);
		
            var _controller = new PrimeNumberOperationsController(_mockService.Object) { CallBase = false };
            var result = _controller.RemovePrimeNumbers("Test123");
		
		    Assert.AreEqual("HAHAHA 2", result, "Error message");
    }
