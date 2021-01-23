    public partial class MainPage : PhoneApplicationPage
    {
        CameraCaptureTask cct = new CameraCaptureTask();
        public MainPage()
        {
            InitializeComponent();
            // Any other initialization tasks
            cct.Completed += new EventHandler<PhotoResult>(cct_Completed);
        }
        void cct_Completed(object sender, PhotoResult e)
        {
            // Do something with `e`
        }
        // Or some other appropriate event
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cct.Show();
        }
