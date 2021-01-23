        private bool _isEditing = false;
        private void datagrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {   _isEditing = true; }
        private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {   _isEditing = false; }
