    public class Account
    {
        public decimal Balance {get; set;}
        public Account() { }
        public Account(decimal balance)
        {
            this.Balance = balance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var listOfAccounts = new List<Account>();
            listOfAccounts.Add(new Account(133.1m));
            Console.WriteLine(listOfAccounts[0].Balance);
            Console.ReadKey(true);
        }
    }
