        [Serializable]
        public class BaseEntity : INotifyPropertyChanged
        {
            [NonSerialized]
            private PropertyChangedEventHandler _propertyChanged;
            
            public event PropertyChangedEventHandler PropertyChanged
            {
                add { _propertyChanged += value; }
                remove { _propertyChanged -= value; }
            }
    
            protected void NotifyPropertyChanged(string propertyName)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        [Serializable]
        public class Person : BaseEntity
        {
            private Address _address;
    
            public Address Address
            {
                get { return _address; }
                set
                {
                    _address = value;
                    NotifyPropertyChanged("Address");
                    Address.PropertyChanged += (s, e) =>
                                                   {
                                                       Console.WriteLine("Address Property Changed {0}", e.PropertyName);
                                                       NotifyPropertyChanged("Address");
                                                   };
                }
            }
    
        }
        [Serializable]
        public class Address : BaseEntity
        {
            private string _city;
            public string City
            {
                get { return _city; }
                set
                {
                    _city = value;
                    NotifyPropertyChanged("City");
                }
            }
        }
        static void Main(string[] args)
        {
           
            var person = new Person();
            person.PropertyChanged += (s, e) => Console.WriteLine("Property Changed {0}", e.PropertyName);
            person.Address = new Address();
            person.Address.City = "TestCity";
        }
