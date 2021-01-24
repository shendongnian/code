     private void btnInvert_Click(object sender, RoutedEventArgs e)
        {
            if (CB1.IsChecked == true && CB3.IsChecked == true)
            {
                CB2.IsChecked = true;
                CB1.IsChecked = false;
                CB3.IsChecked = false;
            }
            else
            {
                CB2.IsChecked = false;
                CB1.IsChecked = true;
                CB3.IsChecked = true;
            }
        }
