        public class FormMainDataGrid : DataGrid
        {
            public FormMainDataGrid() : base() {
                this.IsEnabledChanged += new DependencyPropertyChangedEventHandler(DataGrid_IsEnabledChanged);
                this.SelectionChanged += new SelectionChangedEventHandler(DataGrid_SelectionChanged);
            }
    
            private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs args)
            {
                if (this.IsEnabled)
                {
                    _selectedValue = this.SelectedValue;
                }
            }
    
            private object _selectedValue;
    
            private void DataGrid_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs args)
            {
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    this.SelectedValue = _selectedValue;
                }), null);
            }
        }
