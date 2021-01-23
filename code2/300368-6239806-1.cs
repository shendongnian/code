    static void Main( string[] args ) {
        var foo = new Foo();
        var foobase = foo as FooBase<Bar>;
        Console.WriteLine( "Foo is null? {0}", foo == null );
        Console.WriteLine( "Foo.Bar is null? {0}", foo.Bar == null );
        Console.WriteLine( "FooBase is null? {0}", foobase == null );
        Console.WriteLine( "FooBase.Bar is null? {0}", foobase.Bar == null );
        Console.ReadKey();
    }
