    private DelegateCommand _showMessageCommand;
    public ICommand ShowMessageCommand
    {
        get
        {
             return this._showMessageCommand ?? (this._showMessageCommand = new DelegateCommand(this.ShowMessageExecute, this.CanShowMessageExecute));
            }
        }
