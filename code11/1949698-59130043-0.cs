    public class PivotTest
    {
        public string Party { get; set; }
        public Dictionary<string, double?> Accounts { get; set; }
        public PivotTest()
        {
            Accounts = new Dictionary<string, double?>();
        }
        public void Display()
        {
            Console.WriteLine(Party);
            foreach(string account in Accounts.Keys)
            {
                Console.WriteLine($"{account} {Accounts[account].ToString()}");
            }
        }
    }
