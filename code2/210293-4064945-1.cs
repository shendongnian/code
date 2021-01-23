    private void SomeMethod()
    {
        string newElement = FetchNextElementToAdd():
        SafeUpdate(() => yourListBox.Items.Add(newElement));
    }
    
    private void SafeUpdate(Action action)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(action);
        }
        else
        {
            action();
        }
    }
