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
        public MainViewModel()
        {
            this.Items.Add(new ResearchItem() { Name = "The first research" });
            this.Items.Add(new ResearchItem() { Name = "The second research" });
            this.Items.Add(new ResearchItem() { Name = "The third research" });
        }
    }
