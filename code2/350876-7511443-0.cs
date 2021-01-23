    public sealed class Singleton
    {
        public object Property1 {get;set;}
        public void Method1 (){}
        static Singleton instance = null;
        static readonly object padlock = new object();
        Singleton()
        {
        }
        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance==null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }        
    }
