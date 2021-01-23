    private void opbtn_Click(object sender, RoutedEventArgs e)
    {
        op.BorderBrush = System.Windows.Media.Brushes.Blue;
    
        var dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        dispatcherTimer.Tick += delegate
        {
            op.BorderBrush = System.Windows.Media.Brushes.Red;
            dispatcherTimer.Stop();
        };
    
        dispatcherTimer.Start();
    }
