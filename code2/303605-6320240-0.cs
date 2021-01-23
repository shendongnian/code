    public class A
    {
    public A() {}
    public void Func1()
    {
        Func1Core();
        Func1Core();
    }
    private void Func1Core()
    {
        Console.WriteLine("Calling Func1().");
    }
    public void Func2()
    {
        Console.WriteLine("Calling Func2().");
    }
    }
