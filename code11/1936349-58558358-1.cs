    var Result = resultSet.Select( t => new ApiTransaction()
    {
        ID = t.ID,
        Name = Accounts.Single( a => a.ID == t.AccountID ).Name,
        Surname = Accounts.Single( a => a.ID == t.AccountID ).Surname,
        Company = Accounts.Single( a => a.ID == t.AccountID ).Company,
        VatNumber = Accounts.Single( a => a.ID == t.AccountID ).VatNumber,
        Action = t.Action,
        Credit = t.Credit,
        Debit = t.Debit,
        Details = t.Details,
        Timestamp = t.Timestamp
    } );
