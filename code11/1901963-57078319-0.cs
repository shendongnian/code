    private void Load_Click(object sender, RoutedEventArgs e)
    {
        text.Text = "";
        LoadText().ContinueWith(t =>
        {
            text.Text = text.Text + newValue;
            text.Text = text.Text + "Ashokkumar Viswanathan";
        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
