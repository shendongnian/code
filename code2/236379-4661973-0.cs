    using System;
    
    class Example
    {
        static void Main()
        {
            SomeOtherFunction();
        }
    
        static void SomeFunction()
        {
            throw new MyException("some error");
    
        }
    
        static void SomeOtherFunction()
        {
            try
            {
                SomeFunction();
            }
            catch (MyException)
            {
                Console.WriteLine("caught the exception");
            }
        }
    }
    
    class MyException : Exception
    {
        public MyException(string message)
            : base(message) { }
    }
