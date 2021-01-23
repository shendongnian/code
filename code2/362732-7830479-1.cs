    static IEnumerable<IGrouping<object,Transaction>> GroupBy(string propName) 
    { 
        List<Transaction> transactions = new List<Transaction>  
        { 
            new Transaction{ PaymentMethod="AA", SomeDateTime=DateTime.Now.AddDays(-1), SomeDecimal=1.2M, SomeInt64=1000}, 
            new Transaction{ PaymentMethod="BB", SomeDateTime=DateTime.Now.AddDays(-2), SomeDecimal=3.4M, SomeInt64=2000}, 
            new Transaction{ PaymentMethod="AA", SomeDateTime=DateTime.Now.AddDays(-1), SomeDecimal=3.4M, SomeInt64=3000}, 
            new Transaction{ PaymentMethod="CC", SomeDateTime=DateTime.Now.AddDays(2), SomeDecimal=5.6M, SomeInt64=1000}, 
        }; 
        var arg = Expression.Parameter(typeof(Transaction), "transaction"); 
        var body = Expression.Convert(Expression.Property(arg, propName), typeof(object)); 
        var lambda = Expression.Lambda<Func<Transaction, object>>(body, arg); 
        var keySelector = lambda.Compile(); 
     
        var groups = transactions.GroupBy(keySelector); 
        return groups; 
    } 
