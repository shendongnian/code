        private void myButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var myButton = (Button)sender;
            var grid = myButton.Parent as Grid;
            if (grid != null)
            {
                // do stuff
            }
        }
