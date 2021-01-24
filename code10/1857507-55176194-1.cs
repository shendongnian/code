    private int exvalue = -1;
    
        public int Value
        {
            get { return Math.Abs(exvalue); }
            set { exvalue = value;  OnPropertyChanged(new PropertyChangedEventArgs("Value"));}
        }
        
