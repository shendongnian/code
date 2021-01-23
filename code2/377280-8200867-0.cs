    int field1;
    int field2;
    int field3;
    
    public MyClass()
    {
      field1 = 12;
      field2 = 1;
      field3 = 5;
    }
    public MyClass(int SomeValue) : this()
    {
       field1 = SomeValue;
    }
    public MyClass(int SomeValue, int SomeOtherValue) : this()
    { 
      
       field1 = SomeValue;
       field2 = SomeOtherValue;
    }
