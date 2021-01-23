    using System;
    public struct MyStruct
    {
        public static implicit operator int(MyStruct myStruct)
        {
            return 2;
        }
    }
    public class Test
    {
        public static void Main(string[] args)
        {
            var myStruct = new MyStruct();
            var myInt = myStruct + 5;
            Console.WriteLine("Int value: {0}", myInt);
        }
    }
