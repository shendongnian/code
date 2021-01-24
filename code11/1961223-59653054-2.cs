    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ResearchItem> Items { get; } = new ObservableCollection<ResearchItem>();
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
