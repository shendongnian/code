    using System;
    interface ISomeInterface
    {
        void Foo();
        int MyValue { get; }
    }
    struct SomeStruct : ISomeInterface
    {
        void ISomeInterface.Foo()
        {
            this.myValue++;
        }
        int ISomeInterface.MyValue
        {
            get { return myValue; }
        }
        public int myValue;
    }
    class Program
    {
        static void SomeFunction(ISomeInterface value)
        {
            value.Foo();
        }
        static void Main(string[] args)
        {
            SomeStruct test1 = new SomeStruct();
            ISomeInterface test2 = test1;
            // Call with struct directly
            SomeFunction(test1);
            Console.WriteLine(test1.myValue);
            SomeFunction(test1);
            Console.WriteLine(test1.myValue);
            // Call with struct converted to interface
            SomeFunction(test2);
            Console.WriteLine(test2.MyValue);
            SomeFunction(test2);
            Console.WriteLine(test2.MyValue);
        }
    }
