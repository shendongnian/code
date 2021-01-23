    public class Foo 
    {
         public string Test()     
         {         
             return GetName();
         }
         
         public virtual string GetName()
         {
             return "Foo";
         }
    }
    public class Bar : Foo 
    {
         public override string GetName()
         {
             return "Bar";
         }
    } 
