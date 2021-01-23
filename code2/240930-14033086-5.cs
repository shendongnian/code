    public class Link
    {
        public static class Builder
        {
            private static Action DefaultAction = () => Console.WriteLine("Action not set.");
            public static Link Build(String ID, Action OnClick = null, Action OnFoo = null, Action OnBar = null)
            {
                return new Link(ID, OnClick == null ? DefaultAction : OnClick, OnFoo == null ? DefaultAction : OnFoo, OnBar == null ? DefaultAction : OnBar);
            }
        }
        public Action OnClick;
        public Action OnFoo;
        public Action OnBar;
        public String ID
        {
            get;
            set;
        }
        private Link(String ID, Action Click, Action Foo, Action Bar)
        {
            this.ID = ID;
            this.OnClick = Click;
            this.OnFoo = Foo;
            this.OnBar = Bar;
        }
    }
