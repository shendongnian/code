        private void myCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myCombo.SelectedItem == NY)
            {
                result.Text = "You Selected NY";
            }
            else if (myCombo.SelectedItem == DC)
            {
                result.Text = "You Selected DC";
            }
            else if (myCombo.SelectedItem == CA)
            {
                result.Text = "You Selected CA";
            }
        }
