    private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.System)
            {
                if (e.SystemKey == Key.F10)
                {
                    buyerName.Focus();
                }
            } else if (e.Key == Key.F11)
            {
                discount.Focus();
            }
        }
