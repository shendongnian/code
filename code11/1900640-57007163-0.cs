    // Instantiate QueryExpression QEaccount
    var QEaccount = new QueryExpression("account");
    QEaccount.TopCount = 5;
    
    // Add columns to QEaccount.ColumnSet
    QEaccount.ColumnSet.AddColumns("name", "ah_account_type", "accountid");
    QEaccount.AddOrder("name", OrderType.Descending);
