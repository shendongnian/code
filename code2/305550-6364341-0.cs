    static void Foo(dynamic duck)
    {
        duck.Quack(); // Called dynamically
    }
    static void Foo(Guid ignored)
    {
    }
    static void Main()
    {
        // Calls Foo(dynamic) statically
        Foo("hello");
    }
