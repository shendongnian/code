    public class MyAttribute : ReadOnlyActionFilterAttribute
    {
        protected override void OnClose(Stream stream)
        {
            var html = new HtmlDocument();
            stream.Position = 0;
            html.Load(stream);
            // play with html
        }
    }
