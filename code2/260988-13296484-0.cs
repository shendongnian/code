    public class HtmlPrettyControl : HtmlGenericControl
    {
        public bool Indent { get; set; }
        public HtmlPrettyControl(string tag) : this(tag, true) { }
        public HtmlPrettyControl(string tag, bool indent) : base(tag)
        {
            Indent = indent;
        }
        protected override void Render(HtmlTextWriter writer)
        {
            // Here you can check if you are running against a production environment
            // and just do base.Render to prevent extra code execution and space in
            // your response to the client
            if (Indent)
            {
                RenderBeginTag(writer);
                writer.WriteLine();
                writer.Indent++;
                base.RenderChildren(writer);
                writer.WriteLine();
                writer.Indent--;
                RenderEndTag(writer);
            }
            else
            {
                base.Render(writer);
            }
            writer.WriteLine();
        }
    }
