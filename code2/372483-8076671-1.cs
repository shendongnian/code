    public void ShowMessageBox(string format, params object[] args)
    {
        MessageBox.Show(string.Format(format, args));
    }
    // ...
    ShowMessageBox("You entered: {0}", someValue);
