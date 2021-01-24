    [Fact]
    public void CannotWithdrawLessThanZero()
    {
        // Arrange
        var account = new Account("User", 23);
        var expectedException = new System.ArgumentOutOfRangeException("amount", AmountLessThanZeroMessage);
        // Act
        account.DepositCash(100);
        var thrownException = Assert.Throws<ArgumentOutOfRangeException>(() => account.WithdrawCash(-10));
        // Assert
        Assert.Equal(expectedException.Message, thrownException.Message);
    }
