        HashSet<DataGridRow> loadedRows
        private void HandleUnloadingRow(object sender, DataGridRowEventArgs e)
        {
            _loadedRows.Remove(e.Row);
        }
        private void HandleLoadingRow(object sender, DataGridRowEventArgs e)
        {
            _loadedRows.Add(e.Row);
        }
