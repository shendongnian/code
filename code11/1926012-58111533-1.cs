    public class BankAccount
    {
        // don't publish your private fields, use properties for public access
        public string Name { get; set; }
        public string CreditCardNumber { get; set; }
    }
    public class BankAccounts
    {
        private List<BankAccount> allAccounts = new List<BankAccount>();
        public BankAccount GetAccount(string cardNumber)
        {
            return allAccounts.FirstOrDefault(x => x.CreditCardNumber == cardNumber);
        }
    }
