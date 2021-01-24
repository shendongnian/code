    var account1st = context.Accounts.Single(x => x.AccountId == 1);
    var account2nd = context.Accounts.Single(x => x.AccountId == 1);
    Console.WriteLine(account1st.Status); // I get "ACTIVE"
    Console.WriteLine(account2nd.Status); // I get "ACTIVE"
    account1st.Status = "INACTIVE";
    Console.WriteLine(account2nd.Status); // I get "INACTIVE"
