    [Fact]
        public async Task RegisterSimpleTest()
        {
            // Arrange
            var mockService = new Mock<IAccountService>();
            mockService.Setup(mock => mock.EmailRegisterAsync( // all you need to mock goes here)
            var controller = new AccountController(mockService.Object);
            var data = new EmailRegisterViewModel()
            {
                Email = "a@a.a",
                Password = "123456",
                ConfirmPassword = "123456"
            };
            // Act
            var result = await controller.Register(data) as ObjectResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
