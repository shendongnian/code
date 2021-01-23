        private bool _columnWidthChanging;
        private bool _handlerAdded;
        private void ColumnWidthPropertyChanged(object sender, EventArgs e)
        {
            // listen for when the mouse is released
            _columnWidthChanging = true;
            if (!_handlerAdded && sender != null)
            {
                _handlerAdded = true;  /* only add this once */
                Mouse.AddPreviewMouseUpHandler(this, BaseDataGrid_MouseLeftButtonUp);
            }
        }
        void BaseDataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_columnWidthChanging) {
                _columnWidthChanging = false;
              // save settings, etc
            }
            if(_handlerAdded)  /* remove the handler we added earlier */
            {
                 _handlerAdded = false;
                 Mouse.RemovePreviewMouseUpHandler(this, BaseDataGrid_MouseLeftButtonUp);
            }
        }
