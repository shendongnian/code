    class Program
    {
        static void Main(string[] args)
        {
              IActionable action = new Derived<Base1>();
              action.open();
              action = new Derived<Base2>();
              action.open();
         }
    }
     // Proxybase is a fake base class. ProxyBase will point to a real base1 or
     // base2
    public class Derived<T>:ProxyBase,IActionable
    {
        public Derived():base(typeof(T))    
        // the open function is not overriden in this case allowing
        // the base implementation to be used
    }
    // this looks like the real base class but it is a fake
    // The proxy simply points to the implementation of base1 or base2 instead
    public abstract class ProxyBase: IActionable
    {
        IActionable obj;
        public ProxyBase(Type type,params object[] args)
        {
                 obj = (IActionable)Activator.CreateInstance(type,args);   
        }
        public virtual void open()
        {
              obj.open();
        }
    }
    // notice base1 and base2 are NOT abstract in this case
    // consider this the original implementation of the base class
    public class Base1: IActionable
    {
          public virtual void open()
          {
                Console.WriteLine("base1 open");
          }
    }
    // here base2 acquired the functionality of base1 and hides base1's open 
       function
    // consider this implementation the new one to replace the original one
    public class Base2: Base1, IActionable
    {
         public new virtual void open()
         {
               Console.WriteLine("base2 open");
         }
    }
    public interface IActionable
    {
        void open();
    }
