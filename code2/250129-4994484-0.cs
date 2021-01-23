    public class TestLazy
    {
        private Lazy<MyClass> m_lazyObj;
        public MyClass MyClassInstance
        {
            get { return m_lazyObj.Value; }
        }
            
        public TestLazy()
        {
            m_lazyObj = new Lazy<string>(() => DoTheHeavyJobToGetMyClassInstance);
        }
    }
