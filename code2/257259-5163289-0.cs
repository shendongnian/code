    void Main()
    {
        var a = new A{I=1};
        Console.WriteLine(a.I);
        DoSomething(a);
        Console.WriteLine(a.I);
        DoSomethingElse(a);
        Console.WriteLine(a.I);
    }
    
    public void DoSomething(A a)
    {
        a = new A{I=2};
    }
    
    public void DoSomethingElse(A a)
    {
        a.I = 2;
    }
    
    public class A
    {
        public int I;
    }
