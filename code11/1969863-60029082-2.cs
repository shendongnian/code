    private string mTest;
        public string Test
        {
            get
            {
                return mTest;
            }
       
            set
            {
                if (mTest == value)
                    return;
                mTest = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test)));
            }
       
        }
