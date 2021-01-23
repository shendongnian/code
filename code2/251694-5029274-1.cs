    struct Structure
    {
        public Structure(int a, int b)
        {
            propertyA = a;
            propertyB = b;
        }
        private readonly int propertyA, propertyB;
        public int PropertyA { get { return propertyA; } }
        public int PropertyB { get { return propertyB; } }
    }
