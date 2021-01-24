    public class Singleton
    {
        static Singleton()
        {
            Singleton.Instance = new Singleton();
        }
        public static Singleton Instance { get; }
        private Singleton(){ 
        }
    }
    
