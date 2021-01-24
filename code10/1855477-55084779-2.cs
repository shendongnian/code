    public class TestAtmCustomer
    {
        [Test]
        public void Should_ShowZeroErrorMessage_OnPlaceDeposit_When_AmountIsZero()
        {
            var mock = new MockMessagePrinter();
            ATMCustomer atmCustomer = new ATMCustomer(mock, new RepoTransaction());
            atmCustomer.PlaceDeposit(new BankAccount(), 0);
            var expectedMessage = "Amount needs to be more than zero. Try again.";
            Assert.AreEqual(expectedMessage, mock.Message);
        }
    }
