    public class RichTextBoxCustom : RichTextBox
    {
        protected override void OnContentsResized(ContentsResizedEventArgs e)
        {
            base.OnContentsResized(e);
            this.Height = e.NewRectangle.Height + 10;
        }
    }
