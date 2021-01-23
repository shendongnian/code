    class Foo: IFoo //foo lives in project 1 (depends on project 2 and 3)
    {
        public Bar GetNewBar()
        {
            return new Bar(this);
        }
        public void DoSomething(){}
    }
    public class Bar //bar lives in project 2 (depends on project 3)
    {
        public Bar(IFoo parent){}
    }
    public interface IFoo //IFoo lives in project 3 (depends on nothing)
    {
        void DoSomething();
    }
