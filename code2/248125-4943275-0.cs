        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 10; i++)
            {
                var image_new = new Image();
                var pi = new PanoramaItem();
                var bi = new BitmapImage(new Uri("/Background.png", UriKind.Relative));
                image_new.Source = bi;
                pi.Content = image_new;
                image_panaroma.Items.Add(pi);
            }
        }
