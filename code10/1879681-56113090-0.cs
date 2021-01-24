    private void btnClear_Click(object sender, RoutedEventArgs e)
    {
        Button clickedButton = (Button)sender;
        DailySessions.Items.Remove(clickedButton.DataContext as DailySession);
    }
