    public partial class MainWindow : Window
    {
        public List<DataGridItems> ItemsSource { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Enumerable.Range(1, 10).Select(a => new DataGridItems { Name1 = a.ToString(), Name2 = "Last" + a.ToString() });
        }
        
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DescriptionAttribute descriptionAttribute = typeof(DataGridItems)
                .GetProperty(e.PropertyName)?
                .GetCustomAttributes(true)?
                .OfType<DescriptionAttribute>()
                .FirstOrDefault();
            if (descriptionAttribute != null)
                e.Column.Header = descriptionAttribute.Description;
        }
    }
