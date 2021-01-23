    /// <summary>
    /// Saves changes Command
    /// </summary>
    public ICommand SaveCommand
    {
        get
        {
            if (_saveCommand == null)
                _saveCommand = new RelayCommand(param => this.SaveChanges(), param => this.CanSave);
            return _saveCommand;
        }
    }
