    using Bank = Test.Bank1;
    namespace Test
    {
        public class Bank1
        {
            public uint Balance { get; set; }
            public override string ToString() => $"Balance is {Balance}";
        }
        public class Bank2
        {
            public decimal Balance { get; set; }
            public override string ToString() => $"Balance is {Balance:N2}";
        }
        public class Program
        {
            private static void Main(string[] args)
            {
                var bank = new Bank();
                bank.Balance = 100;
                Console.WriteLine(bank);
                GetKeyFromUser("\nDone! Press any key to exit...");
            }
        }
    }
