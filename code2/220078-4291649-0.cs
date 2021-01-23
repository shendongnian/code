    public void UpdateText(string text)
    {
        if (InvokeRequired) Invoke(() = UpdateText(text));
        else myLabel.Text = text;
    }
