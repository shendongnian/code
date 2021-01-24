    class Base
    {
        public string myString;
        protected Base(object obj) { }
        public Base(string str)
        {
            Console.WriteLine("\tTracing: ctor 'Base(string)' called");
            myString = myString ?? "Hi";
            myString += str;
        }
    }
