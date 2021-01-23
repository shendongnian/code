    public class HtmlScript : HtmlGenericControl
    {
        public HtmlScript() : base("script") { }
        public HtmlScript(string tag) : base(tag) { }
        public string Src
        {
            get
            {
                return this.Attributes["src"];
            }
            set
            {
                this.Attributes["src"] = value;
            }
        }
        protected override void RenderAttributes(HtmlTextWriter writer)
        {
            Src = ResolveClientUrl(Src);
            base.RenderAttributes(writer);
        }
    }
