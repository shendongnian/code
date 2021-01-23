    class Foo //foo lives in project 1 (depends on project 2)
    {
        public Bar GetNewBar()
        {
            return new Bar(this);
        }
        public void DoSomething(){}
    }
    public class Bar //bar lives in project 2 (depends on project 1 -- cant do this)
    {
        public Bar(Foo parent){}
    }
