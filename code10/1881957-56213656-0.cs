    class Program
    {
        static void Main(string[] args)
        {
            ArrayList listOfAccounts = new ArrayList();
            double amt = double.Parse("133.1");
            listOfAccounts.Add(new Account(amt));
            Console.WriteLine(((Account)listOfAccounts[0]).balance.ToString());
            Console.ReadLine();
        }
    }
    public class Account
    {
        public double balance;
        public Account() { }
        public Account(double balance)
        {
            this.balance = balance;
        }
    }
