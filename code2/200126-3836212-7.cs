    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.LoadItems();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                this.LoadItems();
            }
    
            private void LoadItems()
            {
                this.DataContext = new { Items = new List<string> { "Item1", "Item2", "Item3" } };
                this.SelectFirstItem();
            }
    
            private void dg_Loaded(object sender, RoutedEventArgs e)
            {
                SelectFirstItem();
            }
    
            void SelectFirstItem()
            {
                if ((dg.Items.Count > 0) &&
                    (dg.Columns.Count > 0))
                {
                    //Select the first column of the first item.
                    dg.CurrentCell = new DataGridCellInfo(dg.Items[0], dg.Columns[0]);
                    dg.SelectedCells.Add(dg.CurrentCell);
                }
            }
    
            private void dg_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                this.SelectFirstItem();
            }
        }
    }
