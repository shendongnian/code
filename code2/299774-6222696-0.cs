    public sealed class mSingleton
    {
        static readonly mSingleton _instance = new mSingleton();
        public int MyVal { get; set; }
        public static mSingleton Instance
        {
            get { return _instance; }
        }
        private mSingleton()
        {
            // Initialize members, etc. here.
        }
    }
