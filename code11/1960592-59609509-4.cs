    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ColumnOne")
            {
                var binding = new Binding("ColumnWidth");
                binding.Source = this.DataContext;
                BindingOperations.SetBinding(e.Column, DataGridColumn.MinWidthProperty, binding);
                BindingOperations.SetBinding(e.Column, DataGridColumn.MaxWidthProperty, binding);
            }
        }
    }
