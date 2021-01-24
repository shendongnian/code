    public class MyDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ObservableCollection<MyItem> ListResult { get; }
        
        public MyItem MySelectedItem
        {
            get => this._MySelectedItem;
            set
            {
                this._MySelectedItem= value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SelectedItem)));
            }
        }
        private MyItem _MySelectedItem;
    }
