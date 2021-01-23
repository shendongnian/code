        private void columnHeadingLoaded(object sender, RoutedEventArgs e)
        {
            ((ComboBox)sender).ItemsSource = myList;
            ((ComboBox)sender).SelectedIndex = 0;
        }
        // My columns are named "1", "2" etc
        private void columnHeadingSelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            int columnIndex = int.Parse(((ComboBox)sender).DataContext.ToString()) - 1;
            if (((ComboBox)sender).SelectedIndex == 0)
            {
                this.Headings[columnIndex] = null;
            }
            else
            {
                this.Headings[columnIndex] = ((ComboBox)sender).SelectedValue.ToString();
            }
        }
