    public static void DoSomething(MyObject x)
    {
        x.MyProperty = 2;
        x = new MyObject(); // now we lost our reference to original object
        x.MyProperty = 3; // The original object is NOT updated.
    }
    public static void Main(string[] args)
    {
        var y = MyObject();
        y.MyProperty = 1;
        DoSomething(y);
        Console.WriteLine(y.MyProperty); // Will output "2"
    }
