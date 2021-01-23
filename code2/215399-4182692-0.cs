    public bool MyMethod()
    {
        bool a;
        Console.Write(a); // This is NOT OK.
        bool b = false;
        Console.Write(b); // This is OK.
    }
    class MyClass
    {
        private bool _a;
        public void MyMethod()
        {
            Console.Write(_a); // This is OK.
        }
    }
