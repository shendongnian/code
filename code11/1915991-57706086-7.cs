    public partial class ScreenSaverControl : UserControl
    {
        public static readonly DependencyProperty ImageDirectoryProperty =
            DependencyProperty.Register(
                nameof(ImageDirectory), typeof(string), typeof(ScreenSaverControl),
                new PropertyMetadata(ImageDirectoryPropertyChanged));
        private readonly DispatcherTimer timer = new DispatcherTimer();
        private string[] imagePaths = new string[0];
        private int currentImageIndex = -1;
        public ScreenSaverControl()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += (s, e) => NextImage();
            timer.Start();
        }
        public string ImageDirectory
        {
            get { return (string)GetValue(ImageDirectoryProperty); }
            set { SetValue(ImageDirectoryProperty, value); }
        }
        private static void ImageDirectoryPropertyChanged(
            DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var ssc = (ScreenSaverControl)o;
            var directory = (string)e.NewValue;
            if (!string.IsNullOrEmpty(directory) && Directory.Exists(directory))
            {
                ssc.imagePaths = Directory.GetFiles(directory, "*.jpg");
            }
            else
            {
                ssc.imagePaths = new string[0];
            }
            ssc.currentImageIndex = -1;
            ssc.NextImage();
        }
        private void NextImage()
        {
            if (imagePaths.Length > 0)
            {
                if (++currentImageIndex >= imagePaths.Length)
                {
                    currentImageIndex = 0;
                }
                SetImage(new BitmapImage(new Uri(imagePaths[currentImageIndex])));
            }
        }
        private void SetImage(ImageSource imageSource)
        {
            var fadeOut = new DoubleAnimation(0d, TimeSpan.FromSeconds(1));
            var fadeIn = new DoubleAnimation(1d, TimeSpan.FromSeconds(1));
            var newImage = image1;
            var oldImage = image2;
            if (image1.Source != null)
            {
                newImage = image2;
                oldImage = image1;
            }
            fadeOut.Completed += (s, e) => oldImage.Source = null;
            oldImage.BeginAnimation(OpacityProperty, fadeOut);
            newImage.BeginAnimation(OpacityProperty, fadeIn);
            newImage.Source = imageSource;
        }
    }
