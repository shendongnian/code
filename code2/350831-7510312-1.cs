    private void btnOK_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
    
            private void btnCancel_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
    
            private void tbxSearchString_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                MessageBox.Show("search");
                e.Handled = true;
            }
