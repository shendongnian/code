    private void ToggleButton_Checked(object sender, RoutedEventArgs e)
            {
                // IF condition
                {
                    Task.Run(() =>
                    {
                        Thread.Sleep(500);
                        Dispatcher.Invoke(() =>
                        {
                            tgButton.Unchecked -= tgButton_Unchecked;
                            tgButton.IsChecked = false;
                        });                 
                    }).
                    ContinueWith((tsk) =>
                    {
                        tgButton.Unchecked += tgButton_Unchecked;
                    });
                }
            }
