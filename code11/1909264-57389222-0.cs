    private ObservableCollection<Trade> _trades;
    public ObservableCollection<Trade> Trades
    {
        get => _trades;
        set
        {
            _trades = value;
            RaisePropertyChanged("Trades");
        }
    }
