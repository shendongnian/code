        private bool _columnWidthChanging;
        private void ColumnWidthPropertyChanged(object sender, EventArgs e)
        {
            // listen for when the mouse is released
            _columnWidthChanging = true;
            if (sender != null)
                Mouse.AddPreviewMouseUpHandler(this, BaseDataGrid_MouseLeftButtonUp);
        }
        void BaseDataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_columnWidthChanging) {
                _columnWidthChanging = false;
              // save settings, etc
            }
        }
