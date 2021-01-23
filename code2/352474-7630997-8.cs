    public void AddTransaction()
    {
        Account c1 = accountRepository.GetLastAccount();
        Transaction t1 = new Transaction() { Account = c1, Tag = DateTime.Now };
        c1.Transactions.Add(t1);
        transactionRepository.Add(t1);
        accountRepository.Save();
        transactionRepository.Save();
        LoadCollections();
    }
