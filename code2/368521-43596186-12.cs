    public class Singleton {
       // static members
       public static Singleton Instance { get; } = new Singleton();
    
       // instance members
       private Singleton() { } // private so no one else can accidentally create an instance
       public string Gorp { get; set; }
    }
