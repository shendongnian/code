    using System;
    interface ISomeInterface<T>
    {
        void Foo();
        T MyValue { get; }
    }
    struct SomeStruct : ISomeInterface<int>
    {
        public void Foo()
        {
            this.myValue++;
        }
        public int MyValue
        {
            get { return myValue; }
        }
        private int myValue;
    }
    class Program
    {
        static void SomeFunction(ISomeInterface<int> value)
        {
            value.Foo();
        }
        static void Main(string[] args)
        {
            SomeStruct test1 = new SomeStruct();
            ISomeInterface<int> test2 = test1;
            // Call with struct directly
            SomeFunction(test1);
            Console.WriteLine(test1.MyValue);
            SomeFunction(test1);
            Console.WriteLine(test1.MyValue);
            // Call with struct converted to interface
            SomeFunction(test2);
            Console.WriteLine(test2.MyValue);
            SomeFunction(test2);
            Console.WriteLine(test2.MyValue);
        }
    }
