    public class Singleton{
    
        private static Singleton _instance = new Singleton();
        public static Singleton Instance { 
            get => _instance;
        }
    ...
