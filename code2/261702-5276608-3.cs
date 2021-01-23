    public class ReadOnlyControl<T> : WebControl where T : Control, ITextControl {
        protected T inputControl;
        protected Label lblLabel;
        public bool IsReadOnly { get; set; }
        public string Text { get; set; }
        protected override void  Render(HtmlTextWriter writer) {
            Control control = IsReadOnly ? lblLabel : (Control)inputControl;
            ((ITextControl)control).Text = Text;
 	        control.RenderControl(writer);
        }
    }
