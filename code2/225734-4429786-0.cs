    using System;
     
    namespace addsubs
    {
        /// <summary>
        /// Summary description for Class1.
        /// </summary>
        public class addsubs : MarshalByRefObject, IMultiplier //what you compiled from WSDL
        {
            public int product;
            public int multiply(int a, int b)
            {
                product = a * b;
                return product;
            }
        }
    }
