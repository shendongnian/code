    class MyDataGrid : DataGrid, INotifyPropertyChanged
    {
        private DataGridLength _columnWidth;
        public DataGridLength ColumnWidth
        {
            get { return _columnWidth; }
            set
            {
                _columnWidth = value;
                NotifyPropertyChanged("ColumnWidth");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
