    public partial class MainWindow : Window
    {
        private readonly ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
            foreach (string imageFile in Directory.EnumerateFiles(
                @"C:\Users\Public\Pictures\Sample Pictures", "*.jpg"))
            {
                viewModel.Images.Add(new BitmapImage(new Uri(imageFile)));
            }
        }
        private void ZoomInButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel.Scale *= 1.1;
        }
        private void ZoomOutButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel.Scale /= 1.1;
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ImageSource> Images { get; }
            = new ObservableCollection<ImageSource>();
        private double scale = 1;
        public double Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Scale)));
            }
        }
    }
