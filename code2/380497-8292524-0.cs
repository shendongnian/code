    public static class HtmlExtensions
    {
        private class RoleContainer : IDisposable
        {
            private readonly TextWriter _writer;
            public RoleContainer(TextWriter writer)
            {
                _writer = writer;
            }
            public void Dispose()
            {
                _writer.Write("</div>");
            }
        }
        public static IDisposable RoleAccess(this HtmlHelper htmlHelper, string role)
        {
            var user = htmlHelper.ViewContext.HttpContext.User;
            var style = "display:none;";
            if (user.IsInRole(role))
            {
                style = "display:block;";
            }
            var writer = htmlHelper.ViewContext.Writer;
            writer.WriteLine("<div class=\"role_Content_General_Website\" style=\"" + style + "\">");
            return new RoleContainer(writer);
        }
    }
