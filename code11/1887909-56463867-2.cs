    public class MainWindowVM : INotifyPropertyChanged
    {
        private ObservableCollection<string> _myThings;
        public ObservableCollection<string> MyThings { get { return _myThings;} set { _myThings = value; RaisePropertyChanged(); } }
        public MainWindowVM()
        {
            MyThings = new ObservableCollection<string>();
            MyThings.Add("Hallo");
            MyThings.Add("Jello");
            MyThings.Add("Rollo");
            MyThings.Add("Hella");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
