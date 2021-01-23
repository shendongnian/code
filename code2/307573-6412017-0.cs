        class FatherClass
        {
            public int x { get; set; }
        }
    
        class ChildClass : FatherClass
        {
            public int y { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                FatherClass a = new FatherClass();
                ChildClass b = new ChildClass();
    
    
                FatherClass c = (FatherClass)b;
                ChildClass d = (ChildClass)a;
    
                Console.ReadLine();
            }
        }
