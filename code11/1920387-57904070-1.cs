        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            object item = MyDataGrid.SelectedItem;
            
              //// open a window to insert data, or make current row editable.
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
    }
