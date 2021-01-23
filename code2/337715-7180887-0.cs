    class TestArray : INotifyPropertyChanged
    {
        private string[] _nameArray = new string[3];
    
        public TestArray()
        {
            _nameArray[1] = "test name";
        }
    
        public string Name
        {
            get { return _nameArray[0]; }
            set { 
                    _nameArray[0] = value; 
                    NotifyPropertyChanged("Name"); 
                }
        }
    }
