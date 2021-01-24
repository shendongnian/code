    public class MyPage
    {
        public TextBlock tbParagraph;
        public FixedPage page;
        public PageContent content;
        public string Text {get; set;}
    
        public MyPage(string myText)
        {
           Text = myText;
        }
        public PageContent GetPage()
        {
            tbParagraph = new TextBlock();
            page = new FixedPage();
            content = new PageContent();
    
            tbParagraph.Text = Text;
            page.Children.Add(tbParagraph);
            content.Child = page;
            return content;
        }
    }
