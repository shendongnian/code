    public abstract class ParentClass
    {
      /* virtual */ ParentClass /* func */ SomeOperation ( )
      {
         return null;
      }
    
     /* virtual */ void /* func */ SayHello ( )
     {
       // output "hello from ParentClass";
     }
    } // class
    public /* concrete */ class ChildClass : 
      /* extends */ ParentClass
    {
       /* override */ ParentClass /* func */ SomeOperation ( )
       {
          ChildClass /* var */ Result = new ChildClass ( );
          // assign properties here
          return Result;
       }
    
      /* override */ void /* func */ SayHello ( )
      {
         // output "hello from ChildClass"
      }
    } // class
    public /* concrete */ class Demo
    {
       void /* func */ SomeDemo ( )
       {
          ParentClass /* var*/ MyObject =
             new ChildClass ( );
     
          ParentClass /* var */ AnotherObject = 
             MyObject.SomeOperation( );
          AnotherObject.SayHello( );
       }
    }  // class
