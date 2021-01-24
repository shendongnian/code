    public class Item : INotifyPropertyChanged
    {
        [...]
        private int _number1;
        public int Number1
        {
            get
            {
                return _number1;
            }
            set
            {
                if (_number1 != value)
                {
                    _number1 = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _number2;
        public int Number2
        {
            get
            {
                return _number2;
            }
            set
            {
                if (_number2 != value)
                {
                    _number2 = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
