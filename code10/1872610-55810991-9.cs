    public class MyClass : ViewModelBase
    {
        string _myField;
        public string MyProperty
        {
            get => _myField;
            set
            {
                _myField = value;
                OnPropertyChanged();
            } 
        }
    }
 
