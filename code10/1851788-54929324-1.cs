    public MyClassFactory
    {
        public async Task<MyClass> GetAsync()
        {
            var c = new MyClass();
            await c.Method2();
            return c;
        }
    }
