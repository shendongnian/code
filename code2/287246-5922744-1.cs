    static void Main(string[] args)
    {
        B b1 = new B();
        C c1 = new C();
        B b2 = new B();
        C c2 = new C();
    
        Console.Write("{0}; ", b1.GetVariable());  // 1
        Console.Write("{0}; ", b2.GetVariable());  // 1
        Console.Write("{0}; ", c1.GetVariable());  // 2
        Console.Write("{0}; ", c2.GetVariable());  // 2
    
        Console.WriteLine();
    
        c2.Set(333);
    
        Console.Write("{0}; ", b1.GetVariable());  // 1
        Console.Write("{0}; ", b2.GetVariable());  // 1
        Console.Write("{0}; ", c1.GetVariable());  // 333
        Console.Write("{0}; ", c2.GetVariable());  // 333
    
        Console.ReadLine();
    }
