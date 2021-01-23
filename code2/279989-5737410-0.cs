    using System.Reflection;
    public class Shape {
      public string Name { get; set; }
    }
    public class Circle : Shape {}
    public class Square : Shape {}
    public class Foo {
      // non generic method, calls a generic underneath
      public void PrintColourOrNothing( object x ){
        if ( x is Shape ){
          MethodInfo method = this.GetType().GetMethod("PrintColour");
          if ( method != null ){ 
            // supply an array which equates to <T> to MakeGenericMethod, 
            MethodInfo generic = method.MakeGenericMethod( new Type[] { x.GetType() } );
            if ( generic != null ){
              generic.Invoke( this, x ); 
            }
          }
        }
      }
      // generic with type limitations
      public void PrintColour<T>( T thing )
        where T : shape, new()
      {
        Console.WriteLine( "{0} is {1}", typeof(T), thing.Colour );
      }
      ..
      ..
      // call your standard method 
      PrintColourOrNothing( new Square(){ Colour = "Red" } );
    }
