    public void UpdateMyWpfTextBox(string NewText)
    {
        if(!CheckAccess())
           Dispatcher.Invoke(new Action<string>(UpdateMyWpfTextBox), NewText);
        else
           myTextBox.Text = NewText;
    }
