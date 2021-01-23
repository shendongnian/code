    [ParseChildren(false), PersistChildren(true)]
    public partial class SuperDiv : System.Web.UI.UserControl
    {
        public override void RenderControl(HtmlTextWriter writer)
        {
            writer.Write("<div class=\"super\">");
            writer.Write(Controls.Count);
            foreach (Control i in Controls)
                i.RenderControl(writer);
            writer.Write("</div>");
        }
    }
