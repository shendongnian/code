    public partial class ChartEx : UserControl
    {
        public event EventHandler DataSourceChanged;
        public object DataSource
        {
            get { return GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }
        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register(
                "DataSource",
                typeof(object),
                typeof(ChartEx),
                new PropertyMetadata(true, OnDataSourcePropertyChanged));
        private static void OnDataSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ChartEx source = d as ChartEx;
            if (source.DataSourceChanged != null)
                source.DataSourceChanged(source, new EventArgs());
        }
