    public class recordObject : INotifyPropertyChanged
    {
        private int a;
        public int A 
        { 
            get
            {
                return a;
            }
            set
            {
                a = value;
                OnPropertyChanged("A");
            }
        }
    
        private int b;
        public int B
        { 
            get
            {
                return b;
            }
            set
            {
                b = value;
                OnPropertyChanged("B");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
