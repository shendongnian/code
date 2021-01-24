    void Copy(object sender, ExecutedRoutedEventArgs e)
    {
        Clipboard.SetData("My Data", ((TextBox)sender).SelectedText);
    }
    void CanCopy(object sender, CanExecuteRoutedEventArgs e)
    {
        if (sender is TextBox textBox && textBox.SelectionLength > 0)
            e.CanExecute = true;
    }
    void CanPaste(object sender, CanExecuteRoutedEventArgs e)
    {
        if (Clipboard.ContainsData("My Data"))
            e.CanExecute = true;
        e.Handled = true; // prevent other paste handlers
    }
    void Paste(object sender, ExecutedRoutedEventArgs e)
    {
        (sender as TextBox).SelectedText = (string)Clipboard.GetData("My Data");
    }
