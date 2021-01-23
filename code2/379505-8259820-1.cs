    public class DerivedClass : BaseClass
    {
    
      public DerivedClass(){}
      public DerivedClass(string x):base(x)
      {
         result="override"+x; 
         //or as result already be set as x, you can use: result="override" + result;
      }
    
    }
