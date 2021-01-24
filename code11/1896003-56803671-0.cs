    class A    {    }
    
    class B:A  {    }
    
    static string Test<T>(T generic)
    {
        Console.WriteLine("T - generic overload");
        return "Generic overload";
    }
    
    static string Test(A a)
    {
        Console.WriteLine("A - A overload");
        return "A overload";
    }
    
    static string Test(object o)
    {
        Console.WriteLine("object - objectoverload");
        return "object overload";
    }
    
    
    void Main()
    {
        var b =new B() ;
        var a=new A() ;
    
        Test(b);
        Test(a);
    }
