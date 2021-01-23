    public class Account
    {
    }
    public class Customer
    {
        public ArrayList Accounts
        {
            get;
            private set;
        }
        public Customer()
        {
            Accounts = new ArrayList();
        }
        public void AddAccount(Account account)
        {
            // if account is valid add it to the local collection
            Accounts.Add(account);
        }
    }
