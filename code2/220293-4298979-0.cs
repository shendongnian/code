    using System;
    namespace MyLibrary
    {
        public class DomainObject : MarshalByRefObject
        {
            private static int _Value;
            private static void IncrementValue()
            {
                DomainObject._Value++;
            }
            public static int Value
            {
                get
                {
                    return DomainObject._Value;
                }
            }
            public int GetIncrementedValue()
            {
                DomainObject.IncrementValue();
                return DomainObject.Value;
            }
        }
    }
