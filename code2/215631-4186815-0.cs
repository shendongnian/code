    class A
    {
        static void Main()
        {
            B classB = new B();
            DelegateCaller(classB.TheFunction);
        }
    
        public delegate string delFunction();
    
        public static void DelegateCaller(delFunction func) 
        {
            Console.WriteLine(func());
        }
    }
    
    class B
    {
        public string TheFunction()
        {
            return "I'm Printing!!!";
        }
    }
