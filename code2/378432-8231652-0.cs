    public class Foo
    {
        private IFoo wrap = new WrapFoo(this);
        internal IFoo GetIFoo()
        {
            return wrap;
        }
        private class WrapFoo : IFoo
        {
            public WrapFoo(Foo parent)
            {
                //Save parent
            }
            public void DoSomething()
            {
                //Implement interface
            }
        }
    }
