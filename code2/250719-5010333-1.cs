    class MyObject
    {
        private IsDirtyDecorator<int> _myInt = new IsDirtyDecorator<int>(onValueChanged);
        private IsDirtyDecorator<int> _myOtherInt = new IsDirtyDecorator<int>(onValueChanged);
        
        public bool IsDirty { get; private set; }
    
        public int MyInt
        {
            get { return _myInt.Value; }
            set { _myInt.Value = value; }
        }
    
        public int MyOtherInt
        {
            get { return _myOtherInt.Value; }
            set { _myOtherInt.Value = value; }
        }
        
        private void onValueChanged(bool dirty)
        {
            IsDirty = true;
        }
        
    }
