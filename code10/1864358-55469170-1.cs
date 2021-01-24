        private void AskDialog()
        {
            Dialog dialog = new Dialog();
            if (dialog.ShowDialog() == true)
            {
                mainFrame.Content = null;
            }
            else
            {
                // False action
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new Page1(AskDialog);
        }
