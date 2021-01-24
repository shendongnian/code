    public class RichTextBoxCustom : RichTextBox
    {
        public RichTextBoxCustom()
        {
            this.ContentsResized += RichTextBoxCustom_ContentsResized;
        }
        private void RichTextBoxCustom_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            this.Height = e.NewRectangle.Height;
        }
    }
