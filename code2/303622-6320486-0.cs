    public sealed class CSingleTone
    {
        private static CSingleTone instance;
        public int SomeValue{ get; set; }
        public static CSingleTone Instance
        {
            get
            {
                if (instance == null)
                    instance = new CSingleTone();
                return instance;
            }
        }
        private CSingleTone()
        {
        }
    }
