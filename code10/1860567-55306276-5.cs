    public static Task<string> ShowInput(string message, string defaultValue, string title)
    {
        var dialog = new ContentDialog { Title = title };
        var panel = new StackPanel();
        panel.Children.Add(new TextBlock { Text = message, TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap });
        var textBox = new TextBox() { Text = defaultValue };
        textBox.SelectAll();
        var signal = new TaskCompletionSource<string>();
        textBox.KeyUp += (o, e) =>
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                dialog.Hide();
                signal.SetResult(textBox.Text);
            }
            e.Handled = true;
        };
        dialog.PrimaryButtonClick += (o, e) => 
        {
            dialog.Hide();
            signal.SetResult(textBox.Text);
        };
        panel.Children.Add(textBox);
        dialog.Content = panel;
        dialog.PrimaryButtonText = "OK";            
        dialog.ShowAsync();
        return signal.Task;
    }
