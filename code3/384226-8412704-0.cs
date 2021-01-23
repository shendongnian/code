    private void gvRules_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Put each of the columns into programmatic sort mode.
            foreach (DataGridViewColumn column in ((DataGridView)sender).Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
