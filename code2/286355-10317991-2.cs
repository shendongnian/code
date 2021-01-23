    public ICommand StartCommand
    {
        get
        {
            if (this._startCommand == null)
            {
                this._startCommand = new Mvvm.RelayCommand(parm => DoStart(), parm => DoCanStart());
            } return this._startCommand;
        }
    }
    private bool DoCanStart()
    {
        return !IsRunning && ReadyToRun;
    }
    private void DoStart()
    {
        log.Debug("Start test");
        ...
    }
