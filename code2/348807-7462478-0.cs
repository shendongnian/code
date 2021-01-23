    <Canvas x:Name="LayoutRoot" Background="White">
        <Image x:Name="MyImage"></Image>
    </Canvas>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
     
            BitmapImage bi = new BitmapImage();
            bi.UriSource = new Uri("http://www.silverlightdev.net/images/blogImages/Sample.png");
            MyImage.Source = bi;
     
            MyImage.ImageOpened += new EventHandler<RoutedEventArgs>(MyImage_ImageOpened);
        }
     
        void MyImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            // Image load complete.
        }
    }
