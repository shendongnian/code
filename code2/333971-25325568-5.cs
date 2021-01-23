    public class MyAttribute : ReadOnlyActionFilterAttribute
    {
        protected override void OnClose(Stream stream)
        {
            var html = new HtmlDocument();
            html.Load(stream);
            // play with html
        }
    }
