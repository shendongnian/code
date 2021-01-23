    class MyClass
    {
        private int _id;
    
        public MyClass(int id)
        {
            _id = id;
        }
    
        ~MyClass()
        {
            Console.WriteLine("Object " + _id + " deleted at " + DateTime.Now + " .");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MyClass p1 = new MyClass(1);
            p1 = new MyClass(2);
    
            Console.ReadKey();
        }
    }
