    public class ViewModel : INotifyPropertyChanged
    {
        private string _a1;
        public string A1
        {
            get { return _a1; }
            set { _a1 = value; NotifyPropertyChanged(); B1 = value; }
        }
        private string _b1;
        public string B1
        {
            get { return _b1; }
            set { _b1 = value; NotifyPropertyChanged(); }
        }
        //+the same for A2 and B2
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
