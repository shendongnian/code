    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                ucData.RowSelectionChanged += new EventHandler(ucData_RowSelectionChanged);
            }
    
            void ucData_RowSelectionChanged(object sender, EventArgs e)
            {
                var ev = e as SelectionChangedEventArgs;
                var grid = sender as DataGrid;
                ucWelcome.ClientName = "any thing";
                //this is how you can change Welcome UserControl
            }
        }
