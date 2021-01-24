    using System;
    
    namespace lib
    {
        public class Class1
    #if NETCOREAPP3_0
        : System.Reflection.ICustomTypeProvider
    #endif
        {
            public Type GetCustomType()
            {
    #if !NETCOREAPP3_0
                throw new NotSupportedException();
    #else
                return this.GetType(); // return your impl
    #endif
            }
        }
    }
