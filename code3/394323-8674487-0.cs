    public class EvilProperty : IMyInterfaceProperty {}
    public static class X
    {
        public static void EvilMethod(IMyInterface a, IMyInterfaceProperty b)
        {
            a.SomeProperty = b;
        }
    }
