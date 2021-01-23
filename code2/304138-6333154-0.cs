    public class TextFiller
    {
        public TestFiller()
        {
            Text = new HtmlText();
            Details = "";
        }
        public HtmlText Text { get; set; }
        public string Details { get; set; }
    }
    public class HtmlText
    { 
        public HtmlText()
        {
            TextWithHtml = "";
        }
        [AllowHtml]
        public string TextWithHtml { get; set; } 
    }
