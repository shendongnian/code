    public class Internal
    {
        public int MyProperty { get; set; }
    }
    public class WrapperForInternal : INotifyPropertyChanged
    {
        public event PropertyChanged(object sender, PropertyChangedEventArgs e);
        private Internal _i;
        public WrapperForInternal(Internal i)
        {
            _i = i;
        }
        public int MyProperty
        {
            get { return _i.MyProperty; }
            set
            {
                _i.MyProperty = value;
                RaisePropertyChanged("MyProperty");
            }
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
