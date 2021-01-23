        static object _lock=new object(); 
        static IMyInterface _myinterface;
        public static IMyInterface someStuff
        {
            get
            {
                lock (_lock) {
                    if (_myinterface== null)
                    {
                        _myinterface= MyServiceLocator.GetCurrent().GetInstance<IMyInterface>();
                    }
                }
                return _myinterface;
            }
        }
