    static void Main(string[] args)
    {
        var query = GroupBy<string>("PaymentMethod");
        foreach (var group in query)
            Console.WriteLine(group.Key + "," + group.Count());
        var query2 = GroupBy<long>("SomeInt64");
        foreach (var group in query2)
            Console.WriteLine(group.Key + "," + group.Count());
    }
    static IEnumerable<IGrouping<T,Transaction>> GroupBy<T>(string propName)
    {
        List<Transaction> transactions = new List<Transaction> 
        {
            new Transaction{ PaymentMethod="AA", SomeDateTime=DateTime.Now.AddDays(-1), SomeDecimal=1.2M, SomeInt64=1000},
            new Transaction{ PaymentMethod="BB", SomeDateTime=DateTime.Now.AddDays(-2), SomeDecimal=3.4M, SomeInt64=2000},
            new Transaction{ PaymentMethod="AA", SomeDateTime=DateTime.Now.AddDays(-1), SomeDecimal=3.4M, SomeInt64=3000},
            new Transaction{ PaymentMethod="CC", SomeDateTime=DateTime.Now.AddDays(2), SomeDecimal=5.6M, SomeInt64=1000},
        };
        var arg = Expression.Parameter(typeof(Transaction), "transaction");
        var body = Expression.Property(arg, propName);
        var lambda = Expression.Lambda<Func<Transaction, T>>(body, arg);
        var keySelector = lambda.Compile();
        var groups = transactions.GroupBy(keySelector);
        return groups;
    }
        class Transaction
        {
            public string PaymentMethod { get; set; }
            public Int64 SomeInt64 { get; set; }
            public decimal SomeDecimal { get; set; }
            public DateTime SomeDateTime { get; set; }
        }
