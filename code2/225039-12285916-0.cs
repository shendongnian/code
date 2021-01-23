        private bool _isEditing = false;
        private void OnGridBeginEdit(object sender, DataGridBeginningEditEventArgs e)
        {   _isEditing = true; }
        private void OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {   _isEditing = false; }
