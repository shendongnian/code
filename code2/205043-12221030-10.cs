    private ICommand _newFileCommand;
    public ICommand NewFileCommand
    {
        get
        {
            if (_newFileCommand == null)
                _newFileCommand = new UIRelayCommand(p => OnNewFile(p), p => CanNewFile(p), Key.N, ModifierKeys.Control);
            return _newFileCommand;
        }
    }
    protected void OnNewFile(object p)
    {
        //open file...
    }
    protected bool CanNewFile(object p)
    {
        return true;
    }
