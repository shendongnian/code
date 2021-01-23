    private readonly ObservableCollection<Transaction> _allTransactions = new ObservableCollection<Transaction>();
    public ObservableCollection<Transaction> AllTransactions 
    { get { return _allTransactions; } }
    public void LoadCollections()
    {
       // if needed AllTransactions.Clear();
       accountRepository.GetAll().ToList().ForEach(AllTransactions.Add);
       // same for other collections
    }
