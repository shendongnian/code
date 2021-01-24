    [Fact]
    public async Task Create() {
        // arrange
        var account = new CreatingAccount();
    
        var accountRepository = new Mock<IAccountRepository>();
        var createNewAccountUseCase = CreateNewAccountUseCase(accountRepository.Object);
    
        accountRepository.Setup(m => m.Create(It.IsAny<Account>())).Returns(Task.CompletedTask);
    
        var controller = new MyController(createNewAccountUseCase);
        // act
        await controller.CreateAccount(account);
        // assert
        accountRepository.Verify(m => m.Create(It.IsAny<Account>()), Times.Once);
    }
