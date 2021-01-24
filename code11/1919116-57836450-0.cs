class Program
    {
        static void Main(string[] args)
        {
            int balance = 0;
            balance = battle(balance);
        }
        private static int battle(int balance)
        {
            balance = balance + 30;
            return balance;
        }
    }
Or you can create a class-scope variable
class Program
    {
        private static int balance;
        static void Main(string[] args)
        {
            battle(balance);
        }
        private static void battle(int balance)
        {
            balance = balance + 30;
        }
    }
