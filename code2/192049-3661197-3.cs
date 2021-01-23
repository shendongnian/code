    class P
    {
        class B
        {
            public class M { }
        }
        class C : B
        {
            new public void M(){}
        }
        static void Main()
        {
            new C().M(); // 1
            new C.M();   // 2
        }
    }
