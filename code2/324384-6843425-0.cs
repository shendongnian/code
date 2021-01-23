    private void buttonConnect_Click(object sender, RoutedEventArgs e)
    {
        this.Cursor = Cursors.Wait; 
        buttonConnect.IsEnabled = false; 
    
        Action action = buttonConnect.Content.Equals("Connect") ? connect : disconnect;
                
        new Action(() => {
            action();
            Dispatcher.Invoke(() =>
                {
                    buttonConnect.IsEnabled = true;
                    this.Cursor = Cursors.Arrow;
                });
        }).BeginInvoke(null, null);
    }
