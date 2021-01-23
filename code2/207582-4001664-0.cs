    public static class XExtender
    {
        public static void A(this X x)
        {
            x.A(x);
        }
    }
    public class X
    {
        public void A(X x)
        {
        }
    }
