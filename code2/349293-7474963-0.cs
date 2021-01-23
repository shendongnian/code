    public void UpdateMyTextBox(string NewText) 
    {
        if(InvokeRequired)
           Invoke(new Action<string>(UpdateMyTextBox), NewText);
        else
           myTextBox.Text = NewText;
    }
