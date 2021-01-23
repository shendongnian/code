    public delegate void StringDelegate(string message);
    private void ShowMessageBox( string message )
    {
        if (this.InvokeRequired)
        {
            this.Invoke( new StringDelegate( ShowMessageBox, new object[] { message } ));
            return;
        }
        MessageBox.Show( message );
    }
