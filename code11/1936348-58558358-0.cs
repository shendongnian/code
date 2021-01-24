    var Result = resultSet.Select( t => new ApiTransaction()
    {
        ID = t.ID,
        Name = Accounts.Single( a => a.ID == t.ID ).Name,
        Surname = Accounts.Single( a => a.ID == t.ID ).Surname,
        Company = Accounts.Single( a => a.ID == t.ID ).Company,
        VatNumber = Accounts.Single( a => a.ID == t.ID ).VatNumber,
        Action = t.Action,
        Credit = t.Credit,
        Debit = t.Debit,
        Details = t.Details,
        Timestamp = t.Timestamp
    } );
