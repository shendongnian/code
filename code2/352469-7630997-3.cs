    private ObservableCollection<Account> _accounts = new ObservableCollection<Account>();
    public ObservableCollection<Account> Accounts
    {
        get { return _accounts; }
        set
        {
            if (_accounts == value)
                return;
            _accounts = value;
            NotifyPropertyChanged("Accounts");
        }
    }
    private ObservableCollection<Transaction> _transactions = new ObservableCollection<Transaction>();
    public ObservableCollection<Transaction> Transactions
    {
        get { return _transactions; }
        set
        {
            if (_transactions == value)
                return;
            _transactions = value;
            NotifyPropertyChanged("Transactions");
        }
    }
