    public class MyDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ObservableCollection<MyItem> ListResult { get; }
        
        public MyItem SelectedItem
        {
            get => this._SelectedItem;
            set
            {
                this._SelectedItem = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.SelectedItem)));
            }
        }
        private MyItem _SelectedItem;
    }
