    public partial class MainPage : PhoneApplicationPage
    {
        public ObservableCollection<string> SampleDataList { get; set; }
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            if (IsolatedStorageSettings.ApplicationSettings.Contains("SampleDataList"))
            {
                SampleDataList = IsolatedStorageSettings.ApplicationSettings["SampleDataList"] as ObservableCollection<string>;
            }
            else
            {
                SampleDataList = new ObservableCollection<string>();
                SampleDataList.Add("Zero");
                SampleDataList.Add("One");
                SampleDataList.Add("Two");
                SampleDataList.Add("Three");
                SampleDataList.Add("Four");
                SampleDataList.Add("Five");
                SampleDataList.Add("Six");
                SampleDataList.Add("Seven");
                SampleDataList.Add("Eight");
                SampleDataList.Add("Nine");
                SampleDataList.Add("Ten");
                SampleDataList.Add("Eleven");
                SampleDataList.Add("Twelve");
                SampleDataList.Add("Thirteen");
                SampleDataList.Add("Fourteen");
            }
            reorderListBox.ItemsSource = SampleDataList;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            IsolatedStorageSettings.ApplicationSettings["SampleDataList"] = SampleDataList;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }
    }
