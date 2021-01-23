    interface IInterface 
    { 
        public string foo(); 
    }
    class Class1 : IInterface
    {
         public string foo()
         {
             return "Class1";
         }
    }
    class Class2 : IInterface
    {
         public string foo()
         {
             return "Class2";
         }
    }
    public void Something(IInterface obj)
    {
        return foo(obj);
    }
    
