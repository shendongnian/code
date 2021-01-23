    public abstract class Base
    {
       public abstract string Name { get; }
    
       public void Refresh()
       {
         //do something with Name
       }
    }
    
    public class DerivedA
    {
      public override string Name { get { return "Overview"; } }
    }
