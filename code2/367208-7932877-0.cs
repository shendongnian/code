    public static void SayHello(params string[] names){
        foreach(var name in names){
            Console.WriteLine("Hello " + name);
        }
    }
