    public class MySingleton()
    {
        //Could also be a readonly field, or private with a GetInstance method
        public static MySingleton Instance {get; private set;}
        static MySingleton()
        {
            Instance = new MySingleton();
        }
        private MySingleton() { ... }
    } 
    ...
    //in external code
    var mySingletonInstanceRef = MySingleTon.Instance; //right
    var mySingletonInstanceRef = new MySingleton(); //does not compile
    //EDIT: The thread-safe lazy-loaded singleton
     public class MySingleton()
    {
        //static fields with initializers are initialized on first reference, so this behaves lazily
        public static readonly MySingleton instance = new MySingleton();
        //instead of the below you could make the field public, or have a GetInstance() method
        public static MySingleton Instance {get{return instance;}
        
        private MySingleton() { ... }
    } 
