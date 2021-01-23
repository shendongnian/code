    public static class Activator
    {
        public static S1 S1
        {
            get
            {
                return S1.Instance;
                // Or you could do this if you make the S1 constructor public:
                // return new S1();
            }
        }
    }
