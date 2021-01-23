    private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = Edited;
            }
    
     private void businessDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
            {
                Edited = true;
            }
