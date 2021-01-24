    static void Main(string[] args)
    {
        var lstAmmountPerPeriod = new List<AmountPerPeriod>()
        {
            new AmountPerPeriod
            {
                Id = 1,
                StartDate = new DateTime(2019, 03, 21),
                EndDate = new DateTime(2019, 05, 09),
                Amount = 10000
            },
            new AmountPerPeriod
            {
                Id = 2,
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 10),
                Amount = 30000
            },
            new AmountPerPeriod
            {
                Id = 3,
                StartDate = new DateTime(2018, 11, 01),
                EndDate = new DateTime(2019, 01, 08),
                Amount = 20000
            }
        };
        var amountsPerMonth = lstAmmountPerPeriod.SelectMany(AmountPerMonth.FromPeriod);
        Console.WriteLine("ID |month |year   |amount");
        Console.WriteLine("---|------|-------|--------");
        Console.WriteLine(string.Join(Environment.NewLine, amountsPerMonth));
        GetKeyFromUser("\n\nDone! Press any key to exit...");
    }
