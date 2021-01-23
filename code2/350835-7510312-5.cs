    private void btnOK_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = true; 
                this.Close();
            }
    
            private void btnCancel_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
    
            private void tbxSearchString_PreviewKeyDown(object sender, KeyEventArgs e)
            {
               if (e.Key == Key.Enter)
               {
                   this.Search();
                   e.Handled = true;
               }
            }
