    public void UpdateSub(string message)
    {
        subDisplay.subBox.Invoke((action)delegate {
            subDisplay.subBox.Text = message;
        });
    }
