    public class MyClass
    {
       static MyClass _myClass;
       public static MyClass Instance { get { return _myClass; } }
    
       public MyClass()
       {
          _myClass = this;
          ...
       }
       public void Hello()
       {
          Console.WriteLine("CIAO!")
       }
    } 
