    class A
    {
        private B _MyB;
        public A(ISomeBehaviour behaviour)
        {
            _MyB = new B(behaviour);
        }
    }
