    private ObservableCollection<FormEntry> _formEntries;
    public ObservableCollection<FormEntry> FormEntries
    {
        get => _formEntries;
        set
        {
            _formEntries = value;
            // Call the 'RaisePropertyChanged' of the framework you are using
        }
    }
    ...
    FormEntries = new ObservableCollection<FormEntry>(itemsToAdd);
    ...
