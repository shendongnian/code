    using Bridge.Html5;
    
    public class Program
    {
        public static void Main()
        {
            var body = Document.Body;
            HTMLDivElement msg = new HTMLDivElement { Id = "MsgPanel" };
            HTMLAnchorElement linkbtn = new HTMLAnchorElement
            {
                Href = "#",
                InnerHTML = "Click",
                OnClick = (ev) =>
                {
                    HTMLDivElement msgpanel =
                        Document.GetElementById<HTMLDivElement>("MsgPanel");
                    msgpanel.InnerHTML = "MyText";
                }
            };
            body.AppendChild(linkbtn);
            body.AppendChild(msg);
        }
    }
