    public  class StatusViewText:INotifyPropertyChanged
    {
        public StringBuilder statusText { get; set; }
        private string _statusTextString;
        public String statusTextString
        {
            get { return _statusTextString; }
            set 
            { 
                _statusTextString = value; 
                OnPropertyChanged("statusTextString");
            }
        }
        public StatusViewText()
        {
            statusText = new StringBuilder();
        }
        public void Append(string s)
        {
            if (s != null)
            {
                statusText.Append(s);
            }
            statusTextString = statusText.ToString();
        }
        public void AppendLine(string s)
        {
            if (s != null)
            {
                statusText.AppendLine(s);
            }
            statusTextString = statusText.ToString();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    } 
