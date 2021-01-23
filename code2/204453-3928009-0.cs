    public class A
    {
    }
    public class B
    {
        public static void Main(string[] args)
        {
          // Here you're declaring a variable named "a" of type A - it's uninitialized.
          A a;
          // Here you're invoking the default constructor of A - it's now initialized.
          a = new A();
        }
    }
