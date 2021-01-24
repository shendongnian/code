    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    
    namespace XamDataGridUpdateTrigger
    {
        public class NamesModel : NamesDataCollection
        {
            public NamesModel()
            {            
            }
        }
    
        public class NamesDataCollection : ObservableCollection<NamesItem>
        {
            protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                base.OnCollectionChanged(e);
            }       
        }
    
        public class NamesItem : INotifyPropertyChanged
        {
            public NamesItem()
            {            
            }
    
            public NamesItem(string fname, string lname) 
            {
                FirstName = fname;
                LastName = lname;          
             
            }
    
            private string _firstName;
            public string FirstName
            {
                get { return _firstName; }
                set { if (_firstName != value) { _firstName = value; OnPropertyChanged("FirstName"); } }
            }
    
            private string _lastName;
    
            public string LastName
            {
                get { return _lastName; }
                set { if (_lastName != value) { _lastName = value; OnPropertyChanged("LastName"); } }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            
            protected void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                this.PropertyChanged?.Invoke(sender, e);
            }
            protected void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                OnPropertyChanged(this, e);
            }
            protected virtual void OnPropertyChanged(string propertyName)
            {
                OnPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
