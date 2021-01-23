    class MyObject : INotifyPropertyChanged
    {
        private string _Name;
        public string Name { get { return _Name; } set {
            _Name = value; PropertyChanged.SafeInvoke(this,"Name"); } }
        private MyInner _Inner;
        public MyInner Inner { get { return _Inner; } set {
            _Inner = value; PropertyChanged.SafeInvoke(this,"Inner"); } }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    
    class MyInner : INotifyPropertyChanged
    {
        private string _SomeValue;
        public string SomeValue { get { return _SomeValue; } set {
            _SomeValue = value; PropertyChanged.SafeInvoke(this, "SomeValue"); } }
        public event PropertyChangedEventHandler PropertyChanged;
    }
