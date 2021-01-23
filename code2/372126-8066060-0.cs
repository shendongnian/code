    public class eventTitles : INotifyPropertyChanged
    {
        private string _eventtitle = string.Empty;
        
        public string EventTitle
        {
           get {return _eventtitle;}
    
            set
            {
                if (value != _eventtitle)
                {
                    _eventtitle = value;
                    NotifyPropertyChanged("EventTitle");
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
