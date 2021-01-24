    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> MyCollection { get; }
            = new ObservableCollection<string>();
        private string mySelection;
        public string MySelection
        {
            get { return mySelection; }
            set
            {
                mySelection = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(MySelection)));
            }
        }
    }
