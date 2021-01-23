    public abstract class MyBase(string name){}
    public class Concrete1 : MyBase{}
    public class Concrete2 : MyBase{}
    
    public class MyFactory
    {
       public MyBase Create(Criteria criteria)
       {
           //conditional logic/reflection
       }
    }
