    public int MyProperty
    {
         get { return _myProperty; }
         set
            {
               if (value != __myProperty)
               {
                   _subVersion = value;
                   OnPropertyChanged(MyPropertyPropertyName);
                }
            }
    } private int _myProperty; const string MyPropertyPropertyName = "MyProperty";
