    public class Bar : IFoo
    {
        // We don't care if someone calling IFoo wants to pass us something
        // other than a string - we want a string, darn it!
        public void Foo(string y)
        {
            Console.WriteLine(y.Length);
        }
    }
