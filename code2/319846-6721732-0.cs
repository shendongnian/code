    private readonly int a = 20;
        public int A { get { return a; } }
        private int b;
        private bool bInitialized = false;
        public int B
        {
            get { return b; }
            private set
            {
                if (bInitialized) return;
                bInitialized = true;
                b = value;
            }
        }
