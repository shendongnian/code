    public static class MyExtensions 
    { 
        public static string Foo(this HisModule.hisType h) 
        { 
            return String.Format("a={0},b={1},c={2}", h.a, h.b, h.c); 
        } 
    } 
    ....   
    var h = new hisType();   
    Console.WriteLine(h.Foo());
