    public class Window : WebControl {
        public Window() : base(HtmlTextWriterTag.Div) {}
        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, UniqueID);
        }
    }
