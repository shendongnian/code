    public class MyClass : INotifyPropertyChanged
    {
        private object _lock;
        public int MyProperty
        {
            get
            {
                return _myProperty;
            }
            set
            {
                lock(_lock)
                {
                    //The property changed event will get fired whenever
                    //the value changes. The subscriber will do work if the value is
                    //1. This way you can keep your business logic outside of the setter
                    if(value != _myProperty)
                    {
                        _myProperty = value;
                        NotifyPropertyChanged("MyProperty");
                    }
                }
            }
        }
        
        private NotifyPropertyChanged(string propertyName)
        {
            //Raise PropertyChanged event
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class MySubscriber
    {
        private MyClass _myClass;        
        void PropertyChangedInMyClass(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "MyProperty":
                    DoWorkOnMyProperty(_myClass.MyProperty);
                    break;
            }
        }
        
        void DoWorkOnMyProperty(int newValue)
        {
            if(newValue == 1)
            {
                 //DO WORK HERE
            }
        }
    }
