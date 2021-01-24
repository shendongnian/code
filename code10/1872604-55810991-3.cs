    public class MyClass : ViewModelBase
    {
        string _myField;
        string MyProperty
        {
            get => _myField;
            set
            {
                _myField = value;
                OnPropertyChanged();
            } 
        }
    }
