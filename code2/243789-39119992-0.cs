    public interface IFooBar
    {
        void DoSomething(Object obj);
    }
    public class Foo
    {
        public virtual void DoSomething(Object input)
        {
            this.DoSomething(input, false);
        }
        protected virtual void DoSomething(Object input, bool skipSomeBits)
        {
            //Does stuff for Foo and Bar
            if (!skipSomeBits)
            {
                //Does stuff that is specific to Foo but does not need to happen to Bar
            }
        }
    }
    public class Bar : Foo
    {
        public override void DoSomething(object input)
        {
            base.DoSomething(input, true);
        }
    }
