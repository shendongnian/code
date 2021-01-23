    private bool IsDirty { get; set; }
    private int _myInt; // Doesn't need to be a property
    Public int MyInt {
        get{return _myInt;}
        set{_myInt = value; IsDirty = true;}
    }
