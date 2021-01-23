    public class DBWrapper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler Propertychanged;
    
        private string dbName;
    
        public string DBName
        {
            get { return dbName; }
    
            private set
            {
                dbName = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DBName"));
                }
            }
        }
    
        public void SomeMethodThatChangesDBName()
        {
            DBName = "SomethingNew";
        }
    }
