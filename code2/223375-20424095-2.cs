    private bool _IsOpened;
    public bool IsOpened
    {
        get
        {
            return _IsOpened;
        }
        set
        {
            if (!Equals(_IsOpened, value))
            {
                _IsOpened = value;
                RaisePropertyChanged("IsOpened");
            }
        }
    }
    private RelayCommand _UpdateCommand;
    /// <summary>
    /// Insert / Update data entity
    /// </summary>
    public RelayCommand UpdateCommand
    {
        get
        {
            if (_UpdateCommand == null)
            {
                _UpdateCommand = new RelayCommand(
                    () =>
                    {
                        // Insert / Update data entity
                        ...
                        IsOpened = false;
                    },
                    () =>
                    {
                        return true;
                    });
            }
            return _UpdateCommand;
        }
    }
