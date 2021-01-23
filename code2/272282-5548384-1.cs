    public class ToolTextAttribute : MetadataAttribute
    {
        public string Text { get; set; }
        public TooltextAttribute(string text)
        {
            this.Text = new text;
        }
        public override void Process(ModelMetadata modelMetaData)
        {
            modelMetaData.AdditionalValues.Add("ToolText", this.Text);
        }
    }
