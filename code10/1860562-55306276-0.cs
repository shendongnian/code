    /// <summary>
    /// Shows an simple input box to get a string value in return.
    /// </summary>
    /// <param name="title">The title to show at the top of the dialog.</param>
    /// <param name="message">The message shown directly above the input box.</param>
    /// <param name="defaultValue">A value to prepopulate in the input box if any.</param>
    /// <returns></returns>
    public static async Task<string> ShowInput(string message, string defaultValue, string title)
    {
        var dialog = new ContentDialog
        {
            Title = title
        };
        var panel = new StackPanel();
        panel.Children.Add(new TextBlock { Text = message, TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap });
        var textBox = new TextBox();
        textBox.Text = defaultValue;
        textBox.SelectAll();
        TaskCompletionSource<string> signal = new TaskCompletionSource<string>();
        textBox.KeyUp += (o, e) =>
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                dialog.Hide();
                signal.SetResult(textBox.Text);
            }
            e.Handled = true;
        };
        panel.Children.Add(textBox);
        dialog.Content = panel;
        dialog.PrimaryButtonText = "OK";            
        dialog.ShowAsync();
        await signal.Task;
        return signal.Task.Result;
    }
