      public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            LvVorlagen = new ObservableCollection<string>();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LvVorlagen.Add("A");
            LvVorlagen.Add("B");
            LvVorlagen.Add("C");
            LvVorlagen.Add("D");
        }
        public ObservableCollection<string> LvVorlagen
        {
            get;
            set;
        }
        private void BtnIterate_Click(object sender, RoutedEventArgs e)
        {
            foreach(string value in LvVorlagen)
            {
                Debug.WriteLine(value);
            }
        }
    }
