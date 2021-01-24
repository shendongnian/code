    using System;
    using Alpha;
    using Alpha.Middle;
    using Alpha.Middle.Omega;
    using Beta;
    
    public class Horse { }
    
    namespace N
    {
        [Horse]
        class C { }
    }
    
    namespace Alpha
    {
        public class Horse : Attribute { }
    
        namespace Middle
        {
            public class Horse { }
    
            namespace Omega
            {
                public class Horse : Attribute { }
            }
        }
    }
    
    namespace Beta
    {
        public enum Horse { }
    
        public class Foo
        {
            public class Horse : Attribute { }
        }
    }
