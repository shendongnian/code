    public void UpdateSub(string message)
    {
        subDisplay.subBox.Invoke((Action)delegate {
            subDisplay.subBox.Text = message;
        });
    }
