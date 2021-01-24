    [Fact]
    public async Task Create() {
        // arrange
        var account = new CreatingAccount();
    
        var accountRepository = new Mock<IAccountRepository>();
        accountRepository.Setup(m => m.Create(It.IsAny<Account>())).Returns(Task.CompletedTask);
        var createNewAccountUseCase = new CreateNewAccountUseCase(accountRepository.Object);
        
        var controller = new MyController(createNewAccountUseCase);
        // act
        await controller.CreateAccount(account);
        // assert
        accountRepository.Verify(m => m.Create(It.IsAny<Account>()), Times.Once);
    }
