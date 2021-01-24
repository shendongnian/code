    private void Dg_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.EditAction == DataGridEditAction.Commit)
        {
            string message = "Are you sure you want to modify this value?";
            MessageBoxResult result = MessageBox.Show(message, "Confirmation",
            MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                (sender as DataGrid).CancelEdit();
            }
        }
    }
