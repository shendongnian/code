    public ICommand OkCommand
    {
        get
        {
            if (_okCommand == null)
            {
                _okCommand = new ActionCommand<Window>(DoOk, CanDoOk);
            }
            return _okCommand ;
        }
    }
    void DoOk(Window win)
    {
        // Your Code
        win.DialogResult = true;
        win.Close();
    }
    bool CanDoOk(Window win) { return true; }
