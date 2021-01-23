    private void MainWindow_KeyUp(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.System)
            {
                if (mainMenu.Visibility == Visibility.Collapsed)
                    mainMenu.Visibility = Visibility.Visible;
                else
                    mainMenu.Visibility = Visibility.Collapsed;
            }
        }
