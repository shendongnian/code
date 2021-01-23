    var grouped = 
        from month in Enumerable.Range(1, 12)
        select new TransactionDetail()
        {
            Month = month,
            TransactionAmount = RewardTransactions
                .Where(t => t.PurchaseDate.Value.Month == month).Count()
        };
