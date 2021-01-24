    public static class WindowsFormsHostMap
    {
        public static readonly DependencyProperty DataSourceProperty
            = DependencyProperty.RegisterAttached("DataSource", typeof(object), 
                typeof(WindowsFormsHostMap), new PropertyMetadata(OnPropertyChanged));
        public static string GetText(WindowsFormsHost element) => (string)element.GetValue(DataSourceProperty);
        public static void SetText(WindowsFormsHost element, object value) => element.SetValue(DataSourceProperty, value);
        static void OnPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var dataGridView = (sender as WindowsFormsHost).Child as DataGridView;
            dataGridView.DataSource = e.NewValue;
        }
    }
