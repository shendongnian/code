    public partial class ScreenSaverControl : UserControl
    {
        public static readonly DependencyProperty ImageDirectoryProperty =
            DependencyProperty.Register(
                nameof(ImageDirectory), typeof(string), typeof(ScreenSaverControl),
                new PropertyMetadata(ImageDirectoryPropertyChanged));
        private readonly DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(10)
        };
        private string[] imagePaths = new string[0];
        private int currentImageIndex = -1;
        public ScreenSaverControl()
        {
            InitializeComponent();
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
            var fadeOut = new DoubleAnimation
            {
                To = 0d,
                Duration = TimeSpan.FromSeconds(0.5)
            };
            var fadeIn = new DoubleAnimation
            {
                To = 1d,
                Duration = TimeSpan.FromSeconds(0.5),
                BeginTime = fadeOut.Duration.TimeSpan
            };
            fadeOut.Completed += (s, e) =>
            {
                image.Source = imageSource;
                image.BeginAnimation(OpacityProperty, fadeIn);
            };
            image.BeginAnimation(OpacityProperty, fadeOut);
        }
    }
