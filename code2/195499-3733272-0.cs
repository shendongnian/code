    class BaseClass
    {
        public string BaseAttr { get; set; }
    }
    class A : BaseClass
    {
        public string Attr { get; set; }
        public void Method()
        {
            this.Attr = "ok";
            this.BaseAttr = "base ok";
            base.BaseAttr = "ok";
            base.Attr = "unavailable"; //!
        }
    }
