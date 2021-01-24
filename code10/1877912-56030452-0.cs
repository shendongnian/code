    public interface IBase
    {
        string Method();
    }
    
    public abstract class Base : IBase
    {
        public virtual string Method() { return "Sample"; }
    }
    
    public class Implementation : Base // if I add ", IBase" to this it works as expected, but why?
    {
         public override string Method() { return "Overriden"; }
    }
    
    public class Program
    {
        // and it's used like so...
        public static void Main()
        {
            IBase b = new Implementation();
            //Implementation b = new Implementation(); // It works as expected, always using Implementation.Method();
            Console.WriteLine(b.Method()); // Produces "Sample", so Base.Method(). Why not implementation?
            Console.WriteLine(((Implementation) b).Method()); // Produces "Overriden", so Implementation.Method(); Since when I have to downcast to use overriden method!?
        }
    }
    }
