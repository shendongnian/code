    public class MyObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _label;
        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Label"));
                }
            }
        }
        private string _myValue;
        public string MyValue
        {
            get
            {
                return _myValue;
            }
            set
            {
                _myValue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MyValue"));
                }
            }
        }
    }
