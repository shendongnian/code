    class Program
    {
        static void Main(string[] args)
        {
            var listOfAccounts = new List<Account> {new Account(133.1m)};
            Console.WriteLine(listOfAccounts[0].Balance);
            Console.ReadKey(true);
        }
    }
