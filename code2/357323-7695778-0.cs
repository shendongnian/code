        public class User : INotifyPropertyChanged
        {
            private int _key;
            private string _fullName;
            private string _nick;
    
            public int Key
            {
                get { return _key; }
                set { _key = value; NotifyPropertyChanged("Key"); }
            }
            public string NickName
            {
                get { return _nick; }
                set { _nick = value; NotifyPropertyChanged("NickName"); }
            }
            public string Name
            {
                get { return _fullName; }
                set { _fullName = value; NotifyPropertyChanged("Name"); }
            }
    
            public User(String nick, String name, int key)
            {
                this.NickName = nick;
                this.Name = name;
                this.Key = key; 
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public override string ToString()
            {
                return string.Format("{0} {1}, {2}", Key, NickName, Name);
            }
        }
