    #region Multirow editing event =====================================================================================================================================
        
        public delegate void OnEditDelegate(IEnumerable<object> selectedItems, string editedColumnProperty, object newValue);
        public event OnEditDelegate OnEdit;
        private void OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.IsReadOnly)
            {
                return;
            }
            if (((Binding) ((DataGridBoundColumn) e.Column).Binding).Path.Path == null)
            {
                System.Diagnostics.Debug.WriteLine("Bound property is null in extendedDataGrid (OnCellEditEnding)");
                return;
            }
            string editedColumnProperty = ((Binding)((DataGridBoundColumn)e.Column).Binding).Path.Path;
            object newValue = null;
            if (e.EditingElement is TextBox editingTextBox)
            {
                newValue = editingTextBox.Text;
            }
            //object newValue = editingTextBox.Text;
            List<object> selectedItems = new List<object>();
            foreach (DataGridCellInfo info in SelectedCells)
            {
                selectedItems.Add(info.Item);
            }
            //If 2 cells of the same row are selected, the bound item gets added twice. Here we remove those duplicates. Use SelectedItems?
            selectedItems = selectedItems.Distinct().ToList();
            OnEdit?.Invoke(selectedItems, editedColumnProperty, newValue);
        }
        #endregion
    
