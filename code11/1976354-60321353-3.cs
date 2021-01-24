     class Test_Model : INotifyPropertyChanged
     {
            private string col1;
            private string col2;
         
            public string Col1
            {
                get
                {
                    return col1;
                }
                set
                {
                    col1 = value;
                    OnPropertyChanged("Col1");
                }
            }
            public string Col2
            {
                get
                {
                    return col2;
                }
                set
                {
                    col2 = value;
                    OnPropertyChanged("Col2");
                }
            }
           
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
       }
