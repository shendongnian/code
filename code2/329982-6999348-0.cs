       public class A
       {
          public virtual void PrintMe()
          {
             Debug.WriteLine( "PrintMe: A" );
          }
    
          public virtual void PrintMyBase()
          {
          }
       }
    
       public class B : A
       {
          public override void PrintMe()
          {
             Debug.WriteLine( "PrintMe: B" );
          }
    
          public override void PrintMyBase()
          {
             base.PrintMe();
          }
       }
    
       public class C : B
       {
          public override void PrintMe()
          {
             Debug.WriteLine( "PrintMe: C" );
          }
    
          public override void PrintMyBase()
          {
             base.PrintMe();
          }
    
          private void Fun()
          {
             // call C::PrintMe - part one
             PrintMe();
    
             // call B::PrintMe - part two
             PrintMyBase();
    
             // call A::PrintMe - part three
             base.PrintMyBase();
          }
       }
