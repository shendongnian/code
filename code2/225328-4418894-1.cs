    public abstract class MyAbstract {
       private List<Tire> m_Tires;
    
       protected MyAbstract(int count) {
          m_Tires = new List<Tire>(count);
       }
    }
    
    public class MyClass : MyAbstract {
       public MyClass(int count) : base(count) { }   
    }
