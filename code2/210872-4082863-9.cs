    public MainWindow()
    {
        InitializeComponent();
        DependencyPropertyDescriptor dependencyPropertyDescriptor =
            DependencyPropertyDescriptor.FromProperty(DataGridColumn.ActualWidthProperty, typeof(DataGridColumn));
        if (dependencyPropertyDescriptor != null)
        {
            foreach (DataGridColumn column in c_dataGrid.Columns)
            {
                if (GetWrapColumn(column) == true)
                {
                    dependencyPropertyDescriptor.AddValueChanged(column, DataGridColumn_ActualWidthChanged);
                }
            }
        }
        void DataGridColumn_ActualWidthChanged(object sender, EventArgs e)
        {
            c_dataGrid.Width = c_dataGrid.ActualWidth - 1;
            EventHandler eventHandler = null;
            eventHandler = new EventHandler(delegate
            {
                c_dataGrid.Width = double.NaN;
                c_dataGrid.LayoutUpdated -= eventHandler;
            });
            c_dataGrid.LayoutUpdated += eventHandler;
        }
        //...
    }
