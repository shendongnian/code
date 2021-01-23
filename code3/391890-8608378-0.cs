        public DependencyProperty UIDProperty = DependencyProperty.Register("UID", typeof(string), typeof(MainWindow), new FrameworkPropertyMetadata(""));
        string uid = string.empty;
        public string UID
        {
            get 
            { 
                //return Encryption.Decrypt((string)GetValue(UIDProperty));
                Debug.WriteLine("get called");
                return uid; 
            }
            set 
            { 
                // SetValue(UIDProperty, Encryption.Encrypt(value)); 
                 Debug.WriteLine("set called");
                 if(uid != value)
                 {
                     uid = value;
                     NotifyPropertyChanged("UID");
                 }
            }
        }
