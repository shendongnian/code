    public class WithdrawOfNegativeAmountNotAllowedException : Exception
    {
        public WithdrawOfNegativeAmountNotAllowedException(int amount) 
            : base($"Amount is less than zero ({amount})")
        {
        }
    }
    [Fact]
    public void Cannot_withdraw_less_than_zero()
    {
        var account = new Account("User", 23);
        account.DepositCash(100);
        Action withdraw = () => account.WithdrawCash(-10);
        withdraw.Should().Throw<WithdrawOfNegativeAmountNotAllowedException>();
    }
