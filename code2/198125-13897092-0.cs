    public class Foo1
    {
        virtual public int Bar() { return 23; }
    }
    public class Foo2 : Foo1
    {
        override public int Bar() { return 47; }
    }
    public class Foo3 : Foo2
    {
        new public string Bar() { return "Meow"; }
    }
    public static class Tester
    {
        public void Test<T,U>(T param1, U param2) where T:Foo1 where U:Foo3
        {
            var a=param1.Bar();
            var b=param2.Bar();
            Debug.Print("{0} {1}",a,b);
        }
        public static void Test()
        {
          var thing1 = new Foo3();
          Test(thing1, thing1);
        }
    }
