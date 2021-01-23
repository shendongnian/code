    namespace Algebra
    {
        public class Vector3 {}
    }
    
    namespace Test
    {
        using Algebra;
        
        public class Program
        {
            private Vector3 direction = null;
            
            public Vector3 Direction1
            {
                get { return direction; }
            }
    
            public Algebra.Vector3 Direction2
            {
                get { return direction; }
            }
        }
    }
