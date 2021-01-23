    public class Singleton {
       // static members
       private static Singleton _singleton; // instead of here, you can...
       static Singleton() {
          _singleton = new Singleton(); // do it here
       }
       public static Singleton Instance => _singleton;
    
       // instance members
       private Singleton() { } // private so no one else can accidentally create an instance
       public string Gorp { get; set; }
    }
