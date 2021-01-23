    public class Singleton {
       // static members
       private static Singleton _singleton = new Singleton();
       public static Singleton Instance => _singleton
    
       // instance members
       private Singleton() { } // private so no one else can accidentally create an instance
       public string Gorp { get; set; }
    }
