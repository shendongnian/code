    public class MyCoolBase // a base CLASS and not interface
    {
         public virtual void Execute(string a)
         {
            //empty, or NotImplementedException, base on design decision
         }
    
         public virtual void Execute(double b)
         {
            //empty, or NotImplementedException, base on design decision
         }
         public virtual void Execute(int a, int b)
         {
            //empty, or NotImplementedException, base on design decision
         }
    }
    
    public class MyCoolChildOne : MyCoolBase  
    {
         public override void Execute(string a)
         {
            //concrete implementation
         }
    }
    
    public class MyCoolChildTwo : MyCoolBase  
    {
         public override void Execute(int a, int b)
         {
            //concrete implementation
         }
    }
