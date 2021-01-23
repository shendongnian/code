    class HasSingleton
    {
        static public HasSingleton Instance {
            get 
            {
                if (_instance==null)
                {
                    _instance=new HasSingleton();
                }
                return _instance;
            }
        static private _instance;
    }
