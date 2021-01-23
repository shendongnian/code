    [DefaultProperty("DateTimeOffset")]
    [ToolboxData("<{0}:TimeagoDateTimeOffset runat=server></{0}:TimeagoDateTimeOffset>")]
    public class TimeagoDateTimeOffset : WebControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public DateTimeOffset DateTimeOffset
        {
            get { return (DateTimeOffset)ViewState["DateTimeOffset"]; }
            set { ViewState["DateTimeOffset"] = value; }
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.BeginRender();
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "timeago", false);
            writer.AddAttribute(HtmlTextWriterAttribute.Title, DateTimeOffset.ToString("o"));
            writer.RenderBeginTag("abbr");
            writer.Write(DateTimeOffset.ToString("d"));
            writer.RenderEndTag();
            writer.EndRender();
        }
    }
