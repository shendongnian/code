    public partial class MainWindow : Window
    {
        private readonly ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            DataContext = viewModel;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Select Images...";
            if (openFileDialog.ShowDialog() == true)
            {
                viewModel.LoadImages(openFileDialog.FileNames);
            }
        }
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var image = (Image)sender;
            viewModel.ImageFiles.Remove(image.Source);
        }
    }
    public class ViewModel
    {
        public ObservableCollection<ImageSource> ImageFiles { get; }
            = new ObservableCollection<ImageSource>();
        public void LoadImages(IEnumerable<string> imageFiles)
        {
            ImageFiles.Clear();
            foreach (var imageFile in imageFiles)
            {
                ImageFiles.Add(
                    new BitmapImage(new Uri(imageFile, UriKind.RelativeOrAbsolute)));
            }
        }
    }
