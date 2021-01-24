    public class Stuff_NThings : INotifyPropertyChanged
    {
        private int _things;
        private int _moreThings;
        private int _stuff;
        private int _moreStuff;
    
        public int things
        {
            get
            {
                return _things;
            }
            set
            {
                _things = value;
                NotifyPropertyChanged(nameof(things));
            }
        }
        public int moreThings
        {
            get
            {
                return _moreThings;
            }
            set
            {
                _moreThings = value;
                NotifyPropertyChanged(nameof(moreThings));
            }
        }
        public int stuff
        {
            get
            {
                return _stuff;
            }
            set
            {
                _stuff = value;
                NotifyPropertyChanged(nameof(stuff));
            }
        }
        public int moreStuff
        {
            get
            {
                return _moreStuff;
            }
            set
            {
                _moreStuff = value;
                NotifyPropertyChanged(nameof(moreStuff));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
