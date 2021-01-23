    public static void Main(string args[])
    {
        int i=0;
        AddSomething(ref i);
        AddSomething(ref i);
        AddSomething(ref i);
        AddSomething(ref i);
     
        string mystr = "Hello";
        AddSomeText(ref mystr);
        Console.WriteLine(mystr);
        Console.WriteLine("i = {0}", i);
    }
    
    
    public static void AddSomeText(ref string str)
    {
        str+= " World!";
    }
    
    public static void AddSomething(ref int ii)
    {
        ii+=1;
    }
