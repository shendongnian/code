    public int MyProperty
    {
         get { return _myProperty; }
         set
            {
               if (value != _myProperty)
               {
                   _subVersion = value;
                   OnPropertyChanged(() => MyProperty);
                }
            }
    } private int _myProperty; 
