    // test method
    public void AddAccount()
    {
        Account c1 = new Account() { Tag = DateTime.Now };
        accountRepository.Add(c1);
        accountRepository.Save();
        LoadCollections();
    }
    
    // test method
    public void AddTransaction()
    {
        Account c1 = accountRepository.GetLastAccount();
        c1.Transactions.Add(new Transaction() { Tag = DateTime.Now });
        accountRepository.Save();
        LoadCollections();
    }
