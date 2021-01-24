    public interface IBase
    {
        string Method();
    }
    
    public abstract class Base : IBase
    {
        public virtual string Method() { return "Sample"; }
    }
    
    public class Implementation : Base 
    {
         public override string Method() { return "Overriden"; }
    }
    
   
