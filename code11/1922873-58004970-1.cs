    private ICommand loadedCommand;
    public ICommand LoadedCommand
    {
        get { return loadedCommand ?? (loadedCommand = new RelayCommand(Loaded)); }
    }
    private void Loaded(object obj)
    {
        // Logic here
    }
