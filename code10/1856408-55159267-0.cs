    class MyViewModel : INotifyPropertyChanged
        {
            float value1;
            float value2;
            string outputString;
            
            public event PropertyChangedEventHandler PropertyChanged;
    
            public MyViewModel()
            {
                this.Value1 = 1.1f;
                this.Value2 = 1.2f;
                this.OutputString = String.Format("Value1 is {0}; Value2 is {1}", Value1, Value2);
            }
    
            public float Value1
            {
                set
                {
                    if (value1 != value)
                    {
                        value1 = value;
    
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("Value1"));
                        }
                    }
                }
                get
                {
                    return value1;
                }
            }
    
            public float Value2
            {
                set
                {
                    if (value2 != value)
                    {
                        value2 = value;
    
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("Value2"));
                        }
                    }
                }
                get
                {
                    return value2;
                }
            }
    
            public string OutputString
            {
                set
                {
                    if (outputString != value)
                    {
                        outputString = value;
    
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("OutputString"));
                        }
                    }
                }
                get
                {
                    return outputString;
                }
            }
        }
