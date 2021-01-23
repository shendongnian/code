    public static class DataGridUtilities
    {
        public static IDictionary<string,string> GetColumnHeaders(
            DependencyObject obj)
        {
            return (IDictionary<string,string>)obj.GetValue(ColumnHeadersProperty);
        }
        public static void SetColumnHeaders(DependencyObject obj,
            IDictionary<string, string> value)
        {
            obj.SetValue(ColumnHeadersProperty, value);
        }
        public static readonly DependencyProperty ColumnHeadersProperty =
            DependencyProperty.RegisterAttached(
                "ColumnHeaders",
                typeof(IDictionary<string, string>),
                typeof(DataGrid),
                new UIPropertyMetadata(null, ColumnHeadersPropertyChanged));
        static void ColumnHeadersPropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid != null && e.NewValue != null)
            {
                dataGrid.AutoGeneratingColumn += AddColumnHeaders;
            }
        }
        static void AddColumnHeaders(object sender,
            DataGridAutoGeneratingColumnEventArgs e)
        {
            var headers = GetColumnHeaders(sender as DataGrid);
            if (headers != null && headers.ContainsKey(e.PropertyName))
            {
                e.Column.Header = headers[e.PropertyName];
            }
        }
    }
