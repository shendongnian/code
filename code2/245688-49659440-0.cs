    public class BaseClass
    {
       private int _fieldToSet;
       ...
    }
    
    public class DerivedClass : BaseClass
    {
       ...
    }
    
    // Unit Test Code
    
    public void Test()
    {
       DerivedClass d = new DerivedClass();
       PrivateObject privObj = new PrivateObject(d, new PrivateType(typeof(BaseClass));
       privObj.SetFieldOrProperty("fieldToSet", 8675309);
       ...
    }
