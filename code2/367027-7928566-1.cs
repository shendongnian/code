    public static class HtmlExtensions
    {
        private class Table : IDisposable
        {
            private readonly TextWriter _writer;
            public Table(TextWriter writer)
            {
                _writer = writer;
            }
            public void Dispose()
            {
                _writer.Write("</table>");
            }
        }
        public static IDisposable BeginTable(this HtmlHelper html, string id)
        {
            var writer = html.ViewContext.Writer;
            writer.Write(string.Format("<table id=\"{0}\">", id));
            return new Table(writer);
        }
    }
