    public class MySingleton()
    {
        //Could also be a readonly field, or private with a GetInstance method
        public MySingleton Instance {get; private set;}
        static MySingleton()
        {
            instance = new MySingleton();
        }
        private MySingleton() { ... }
    }   
