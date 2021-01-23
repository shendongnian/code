    class Program
    {
        static void Main(string[] args)
        {
            // here you call the single instance of myClass
            myClass myClassInstance = myClass.Instance;
            // run the public someothermethod of myClass
            myClassInstance.SomeOtherMethod();
        }
