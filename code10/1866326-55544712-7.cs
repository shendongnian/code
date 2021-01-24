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
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (MainList.SelectedItem != null)
            {
                Debug.WriteLine("Select Item is: " + MainList.SelectedItem.ToString());
            }
            else
            {
                Debug.WriteLine("No items are selected.");
            }
        }
        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = MainList.SelectedIndex;
            LvVorlagen[selectedIndex] = "X";
        }
    }
