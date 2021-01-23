    public void LoadCollections()
    {
        AllAccounts = accountRepository.GetAll();
        NotifyPropertyChanged("AllAccounts");
        AllTransactions = transactionRepository.GetAll();
        NotifyPropertyChanged("AllTransactions");
    }
    public void InsertTransaction(Transaction transaction)
    {
        AllTransactions.Add(transaction);
        transactionRepository.Add(transaction);
        LoadCollections(); // Tried this to update the Accounts with newer values, but don't work...
    }
