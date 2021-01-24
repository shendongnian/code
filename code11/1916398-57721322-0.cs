    public class Notes: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public int created { get; set; }
        private string myTitle;
        public string title {
            get {
                return myTitle;
            }
            set {
                myTitle = value;
                OnPropertyChanged();
                }
            }
    
    
        public string text { get; set; }
        public int id { get; set; }
        public int updated { get; set; }
    
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
