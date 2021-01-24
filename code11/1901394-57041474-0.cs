    public class TableStruct : INotifyPropertyChanged
    {
        private string _item3;
        public string Item3
        {
            get { return _item3; }
            set { _item3 = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //...
    }
