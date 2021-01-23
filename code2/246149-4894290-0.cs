    public Class MyClass
    {
         public int IntValue {get;set;}
         public bool BoolValue {get;set;}
         public MyClass(int intValue, bool boolValue)
         {
              IntValue = intValue;
              boolValue = boolValue;
         }
    }
    List<MyClass> l1 = new List<MyClass>();
    l1.Add(new MyClass(8, true));
    MyClass pointer = l1[0];
    Console.WriteLine(pointer.IntValue); //writes 8
    Console.WriteLine(pointer.BoolValue); //writes True
    
