     public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                try
                {
                    MediaElement me = new MediaElement();
                    me.MediaEnded += me_MediaEnded;
                    me.MediaFailed += me_MediaFailed;
                    me.MediaOpened += me_MediaOpened;
                    
                    me.Source = new Uri("mms://95.0.159.131/TRTBELGESEL");
    
                    mainGrid.Children.Add(me);
                }
                catch (Exception ex)
                {   
                }
            }
    
            void me_MediaOpened(object sender, RoutedEventArgs e)
            {
                Debug.WriteLine("OPENED"); //  It means OK!
            }
    
            void me_MediaFailed(object sender, ExceptionRoutedEventArgs e)
            {
                Debug.WriteLine("FAILED"); // It means that URL is not working
            }
    
            void me_MediaEnded(object sender, RoutedEventArgs e)
            {
                Debug.WriteLine("ENDED");
       }
        }
