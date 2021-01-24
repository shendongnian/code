    public partial class UserControlCounter : UserControl, INotifyPropertyChanged
    {
        private int _scanStatusCounter;
        public int ScanStatusCounter
        {
            get { return _scanStatusCounter; }
            set { _scanStatusCounter = value; NotifyPropertyChanged(); }
        }
        public UserControlCounter()
        {
            InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var contentPresenter = (btn.TemplatedParent as ContentPresenter);
            var ppStatusCounter = contentPresenter.ContentTemplate.FindName("scanStatus", contentPresenter) as TextBlock;
            await Task.Run(getAll);
            ppStatusCounter.Text = "Persons " + ScanStatusCounter.ToString();
        }
        private static async void getAll()
        {
            //grab data and iterate it
            foreach (var result in data)
            {
                ScanStatusCounter++;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
