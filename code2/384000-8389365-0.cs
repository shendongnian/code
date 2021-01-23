    Object MyFirstObject;
    Object MySecondObject;
    void BindableClass( Object class_1, Object class_2 )
    {
        MyFirstObject = class_1;
        MySecondObject = class_2;
    }
    public String _firstColumnString { get { return MyFirstObject.FirstColumnString; } }    
    public String _secondColumnString { get { return MySecondObject.SecondColumnString; } }
