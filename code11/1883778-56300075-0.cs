    public class DisplayCard : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title) { _title = value; RaisePropertyChanged(); }
            }
        }
        private string _cardImage;
        public string CardImage
        {
            get { return _cardImage; }
            set
            {
                if (value != _cardImage) { _cardImage = value; RaisePropertyChanged(); }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class YourViewVM : INotifyPropertyChanged
    {
        private ObservableCollection<DisplayCard> _cardCollection;
        public ObservableCollection<DisplayCard> CardCollection
        {
            get { return _cardCollection; }
            set
            {
                if (value != _cardCollection) { _cardCollection = value; RaisePropertyChanged(); }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
