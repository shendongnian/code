    var predicate = PredicateBuilder.False<customAccountEntity>();
    // Loop through the local List creating an Or based predicate
    foreach (var item in myAccountsList)
    {
        string temp = item.AccountNumber;
        predicate = predicate.Or (x => x.customCrmEntityAttribute == temp);
    }
    // The variable predicate is of type Expression<Func<customAccountEntity, bool>>
    var myLinqToCrmQuery =  from ax in myObject.ListOfAccounts
                            from cx in orgContext.CreateQuery<customAccountEntity>().AsExpandable().Where(predicate)
                            where ax.AccountNumber == cx.account_number
                            select cx;
    foreach (resultItem in myLinqToCrmQuery)
    {
        Console.WriteLine("Account Id: " + resultItem.Id);
    }
