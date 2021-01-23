    public class Settings {
      public int A {get; set;}
      public int B {get; set;}
      public int C {get; set;}
    }
    
    public class NeedsToUseOtherClass {
      public NeedsToUseOtherClass() {
        Settings foo = new Settings();
        Settings bar = new Settings();
        Settings yoo = new Settings();
    
        foo.setA(25);
      }
    }
