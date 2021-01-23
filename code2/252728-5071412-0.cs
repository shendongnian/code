    public partial class MyPage : PhoneApplicationPage
    {
        MediaElement MEAudio;
    
        public MainPage()
        {
            InitializeComponent();    
            MEAudio = App.GlobalMediaElement;
        }
    
        private void OnSomeEvent(object sender, RoutedEventArgs e)
        {
            MEAudio.xxxxx();
