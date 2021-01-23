    public static class PPMM
    {
        public static double? Factor
        {
            get { return Singleton.Factor; }
            set
            {
                Singleton.Factor = value;
            }
        }
        private static PPMMSingleton _singleton = null;
        public static PPMMSingleton Singleton
        {
            get
            {
                if (_singleton == null)
                    _singleton = new PPMMSingleton();
                return _singleton;
            }
        }
        public static event ppmmEventHandler FactorChanged
        {
            add { Singleton.FactorChanged += value; }
            remove { Singleton.FactorChanged -= value; }
        }
    }
