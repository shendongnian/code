    public abstract class MyAbstract {
       private List<Tire> m_Tires;
    
       protected MyAbstract() {
          m_Tires = new List<Tire>();
       }
    }
    
    public class MyClass : MyAbstract {
       public MyClass() : base() { }   
    }
