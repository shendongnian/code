    // If you invert the order of the operands to MyObject.*() , and expand out the *= in main,
    // the thing runs without throwing the exception :s
    // If you step through, the value of myValue is correctly ‘invalid decimal value’ after * by -1.
    using System;
    namespace ConsoleApplication19
    {
        class Program
        {
            static void Main(string[] args)
            {
                var o1 = (MyObject?)new MyObject(2.34M);
                o1 = -1 * o1 ;
            }
        }
        public struct MyObject
        {
            private Decimal myValue;
            public MyObject(Decimal myValue)
            {
                this.myValue = myValue;
            }
            public static MyObject operator *(Decimal value2,  MyObject value1)
            {
                value1.myValue *= value2;
                return value1;
            }
        }
    }
