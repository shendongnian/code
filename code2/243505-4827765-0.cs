    public partial class TabControl : System.Web.UI.UserControl
    {
        public List<TabObject> TabObjects { get; set; }
        public override void RenderControl(HtmlTextWriter writer)
        {
            writer.Write("<div class=\"tabWrapper\">");
            foreach (var item in TabObjects)
            {
                writer.Write("<div class=\"tab{0}\"><a href=\"{1}\">{2}</a></div>", (item.Selected) ? " tabSelected" : "", item.Link, item.Name);
            }
            writer.Write("<div class=\"clear\"></div>");
            writer.Write("</div>");
            base.RenderControl(writer);
        }
    }
