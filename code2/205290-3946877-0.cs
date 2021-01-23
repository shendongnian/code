    public class Con : Control
    {
        public Template Content { get; set; }
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Content = new Template();
            // load controls from file and add to this control
            Content.InstantiateIn(this);
        }
        public class Template : ITemplate
        {
            public void InstantiateIn(Control container)
            {
                // load controls
                container.Controls.Add((HttpContext.Current.Handler as Page).LoadControl("Emb.ascx"));
            }
        }
    }
