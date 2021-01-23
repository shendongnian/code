    private void SomeMethod(ListBox listBox)
    {
        SafeUpdate(() => listBox.Items.Add("Some element"));
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
