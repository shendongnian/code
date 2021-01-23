    public partial class MyPage : Page, IOverrideRender
    {
        void IOverrideRender.Register(OverrideRender render)
        {
            this.overrideRender = render;
        }
        private OverrideRender overrideRender;
        protected override void Render(HtmlTextWriter writer)
        {
            if(overrideRender != nul)
            {
                overrideRender(writer, base.Render);
            }
            else
            {
                base.Render(writer);
            }
        }
    }
