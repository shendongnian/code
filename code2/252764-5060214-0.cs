    class Base<TDescendant>
        where TDescendant : Base
    {
         public static int x;
         public int myMethod()
         {
              x += 5;
              return x;
         }
    
    }
    
    class DerivedA : Base<DerivedA>
    {
    }
    
    class DerivedB : Base<DerivedB>
    {
    }
