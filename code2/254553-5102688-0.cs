    class Data : INotifyPropertyChanged
    {
        private int _counter = 0;
    
        public event PropertyChangedEventHandler PropertyChanged = (sender, arg) =>
            {
                // if (_counter > 10) Exit();
                // from arg you can know what property is changed
                // which is probably used for future
            };
    
        private int _number;
        public int Number
        {
            get { return _number; }
            set
            {
              //here is another unclear point in your question
              //will the counter increases when setting a.Number = 100 
              //but it's already 100 before setting
                if (_number != value)
                {
                    _number = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Number"));
                }
            }
        }
    }
