    [Fact]
    public async Task Create() {
        // arrange
        var account = new CreatingAccount();
    
        var accountRepository = new Mock<IAccountRepository>();
        accountRepository.Setup(m => m.Create(It.IsAny<Account>())).Returns(Task.CompletedTask);
        var createNewAccountUseCase = CreateNewAccountUseCase(accountRepository.Object);
    
        // act
        await createNewAccountUseCase.Execute(account.ConvertToAccount());
        // assert
        accountRepository.Verify(m => m.Create(It.IsAny<Account>()), Times.Once);
    }
