    class MyClass 
    {
        string _backingField;
        string MyProperty { 
            get { return _backingField; }
            set { this._backingField = value; }
        }
    }
