    public class StatusViewText : INotifyPropertyChanged
    {
        public StatusViewText()
        {
            // At least, I have a default value
            this.StatusTextString = "Hello world";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private string statusTextString;
        public string StatusTextString
        {
            get { return this.statusTextString; }
            set
            {
                this.statusTextString = value;
                this.OnPropertyChanged("StatusTextString");
            }
        }
    }
