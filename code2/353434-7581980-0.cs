    public class MyClass
    {
       Dictionary<int, string> myCollection = new Dictionary<int, string>();
    
       public Dictionary<int, string> Value
       {
          get { return myCollection; }
          set { myCollection = value; }
       }
    }
