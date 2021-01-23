    public class UserAccess : INotifyPropertyChanged
    {
        public int AccessId { get; set; }
        private string access;
        public string Access
        {
            get
            {
                return access;
            }
            set
            {
                access = value;
                RaisePropertyChanged("Access");
            }
        }
        private void RaisePropertyChanged(string propertyName)
        {
            var temp = PropertyChanged;
            if (temp != null)
                temp(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
