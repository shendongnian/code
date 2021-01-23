    class Derived: Base 
    { 
       new private static void F()
       {
           F();      // calls Derived.F()
           Base.F(); // calls Base.F()
       }
    } 
    
    class MoreDerived: Derived 
    { 
       static void G() { F(); }         // Invokes Base.F 
    }
