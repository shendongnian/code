    {
        static void Main(string[] args)
        {
            MyClass objectA = new MyClass();
            MyClass objectB = new MyClass(objectA);
            objectA.val = 10;
            objectB.val = 20;
            Console.WriteLine("objectA.val = {0}", objectA.val);
            Console.WriteLine("objectB.val = {0}", objectB.val);
            Console.ReadKey();
        }
    }
