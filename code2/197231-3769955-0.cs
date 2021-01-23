    public ICommand MyCommand
    {
        get
        {
            return new RelayCommand(p => DoSomething());
        }
    }
