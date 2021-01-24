    public partial class MainWindow : Window
    {
        private readonly ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        private void ListView_Drop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files.Where(
                f => (f.ToLower().EndsWith(".jpg") || f.ToLower().EndsWith(".jpeg"))
                    && !viewModel.Images.Contains(f)))
            {
                viewModel.Images.Add(file);
            }
        }
    }
 
