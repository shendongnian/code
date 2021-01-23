    public class Parent {
       private PrivilegedFunctions p;
       public Parent(PrivilegedFunctions inP) { p = inP; }
    }
    
    public interface PrivilegedFunctions {
       void SomeFuncHere();
    }
    
    public class AllowPrivileges : PrivilegedFunctions {
       public void AllowPrivileges () { }
       public void SomeFuncHere()
       { 
          // Actual implementation
       }
    }
    
    public class NoPrivileges : PrivilegedFunctions {
       public void NoPrivileges () { }
       public void SomeFuncHere()
       { 
          // No implementation
       }
    }
    
    public class Child1 : Parent {
       public Child1(PrivilegedFunctions inP) : base(inP) { }
    }
