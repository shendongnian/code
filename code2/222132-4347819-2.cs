    public class MyClass
    {
        private readonly Func<IProxy> createProxy;
    
        public MyClass(Func<IProxy> createProxy)
        {
            if (createProxy == null)
                throw new ArgumentNullException("createProxy");
            this.createProxy = createProxy;
        }
        
        public void DoSomething()
        {
            using (IProxy proxy = this.createProxy())
            {
                ...
            }
        }
    }
