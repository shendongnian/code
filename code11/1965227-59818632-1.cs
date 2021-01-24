    public partial class MainWindow : Window
    {
        private UniformGrid itemsGrid;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ItemsGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // Set reference and adjust columns/rows once the UniformGrid is loaded.
            itemsGrid = sender as UniformGrid;
            ((UniformGrid)sender).Columns = (int)(Container.ActualWidth / 250);
            ((UniformGrid)sender).Rows = (int)(Container.ActualHeight / 75);
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Adjust number of columns/rows whenevner the window is resized.
            if (itemsGrid != null)
            {
                itemsGrid.Columns = (int)(Container.ActualWidth / 250);
                itemsGrid.Rows = (int)(Container.ActualHeight / 75);
            }
        }
    }
