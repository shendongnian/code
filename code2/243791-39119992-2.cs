    public interface IFooBar
    {
        void DoSomething(Object obj);
    }
    public class Foo
    {
        public virtual void DoSomething(Object input)
        {
            //Does Foo and Bar stuff
            this.DoSomething2(input);
        }
        protected virtual void DoSomething2(Object input)
        {
            //Does Foo stuff
        }
    }
    public class Bar : Foo
    {
        protected override void DoSomething2(Object input)
        {
            //Does not call base.DoSomething2() therefore does nothing or can do Bar stuff if needs be...
        }
    }
