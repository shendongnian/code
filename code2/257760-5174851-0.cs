    public class A
    {
        public int x;
    }
    public void AnotherFunc(A a)
    {
        a.x = 2;
    }
    public void SomeFunc()
    {
        A a = new A();
        a.x = 1;
        AnotherFunc(a);
        // a.x is now 2
    }
