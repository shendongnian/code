    public class MySingleton()
    {
        //Could also be a readonly field, or private with a GetInstance method
        public MySingleton Instance {get; private set;}
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
