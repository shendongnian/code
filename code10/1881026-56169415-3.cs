    public class MyDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ObservableCollection<MyItem> ListResult { get; }
        
        public MyItem MySelectedItem
        {
            get => this._MySelectedItem;
            set
            {
                this._MySelectedItem = value;
                this.PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(this.MySelectedItem)));
            }
        }
        private MyItem _MySelectedItem;
        
        public int MySelectedIndex
        {
            get => this._MySelectedIndex;
            set
            {
                this._MySelectedIndex = value;
                this.PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(this.MySelectedIndex)));
            }
        }
        private int _MySelectedIndex;
    }
