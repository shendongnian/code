     public partial class Data : UserControl
        {
    
            private event EventHandler _RowSelectionChanged;
            public event EventHandler RowSelectionChanged
            {
                add { _RowSelectionChanged += value; }
                remove { _RowSelectionChanged -= value; }
            }
    
            private void RaiseSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (_RowSelectionChanged != null)
                    _RowSelectionChanged(sender, e);
            }
            public Data()
            {
                InitializeComponent();
            }
    
            private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                RaiseSelectionChanged(sender, e);
            }
    
        }
