        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                webView.InvokeScript("eval", "history.go(-1);");
            }
            catch
            {
                // Eat error
            }
        }
        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                webView.InvokeScript("eval", "history.go(1);");
            }
            catch
            {
                // Eat error
            }
        }
