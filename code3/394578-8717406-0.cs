    public new void Show()
    {
        if (_showdialog)
        {
            _dialog.Show(Control.FromHandle(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle));
        }
        else
        {
            _dialog.BringToFront();
        }
    }
