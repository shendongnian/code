    public class MyControl : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    
        private Color _color = null;
        public Color CurrentColor
        {
            get
            {
                return _color;
            }
    
            set
            {
                _color = value;
                NotifyPropertyChanged("CurrentColor");
            }
        }
    }
