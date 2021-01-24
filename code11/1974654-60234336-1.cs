    static void Main(string[] args)
    {
        var myClass = new ServiceCollection()
            .Configure<MyOptions>(o =>
            {
                o.ConnectionString = "bar";
            })
            .AddSingleton<MyClassHere>()
            .BuildServiceProvider()
            .GetService<MyClassHere>();
        myClass.Foo();
        Console.ReadLine();
    }
