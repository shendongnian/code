    public sealed class TestClass
    {
        public enum Levels { A, B, C, D, E, F, G, H, ASE, SE, SSE, TL, AM };                  
        private Levels _levels; 
        public Levels Levels
        {
            get { return _levels; }         
        }
        private static TestClass instance = new TestClass();
        public static TestClass Instance
        {
         get { return instance; }
        }   
    
        public TestClass(){}
    }
