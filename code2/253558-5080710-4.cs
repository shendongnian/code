    public class MyLabel : Label
    {
        protected override override void RenderContents(HtmlTextWriter writer)
        {
            IPage page = new PageWrapper(this.Page);
            this.MethodToTest(page);
            base.RenderContents(writer);
        }
        internal void MethodToTest(IPage page)
        {
            // Work with IPage interface.
            if (page.IsPostBack)
            {
                this.Text = string.Empty;
            }
        }
    }
