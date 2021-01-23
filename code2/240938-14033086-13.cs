    public class Link
    {
        public sealed class Builder
        {
            public Action OnClick;
            public Action OnFoo;
            public Link Build(String ID)
            {
                Link link = new Link(ID);
                link.OnClick = this.OnClick;
                link.OnFoo = this.OnFoo;
                return link;
            }
        }
        public Action OnClick;
        public Action OnFoo;
        public String ID
        {
            get;
            set;
        }
        private Link(String ID)
        {
            this.ID = ID;
        }
    }
