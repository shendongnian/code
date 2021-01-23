    public static class HelperExtensions
    {
        public static MvcHtmlString Menu(this HtmlHelper html, Action<IList<ToolbarAction>> addActions)
        {
            var menuActions = new List<ToolbarAction>();
            addActions(menuActions);
            var htmlOutput = new StringBuilder();
            htmlOutput.AppendLine("<div id='menu'>");
            foreach (var action in menuActions)
                htmlOutput.AppendLine(html.ActionLink(action.Text, action.Action, action.Controller, new { @class = action.Name }).ToString());
            htmlOutput.AppendLine("</div>");
            return new MvcHtmlString(htmlOutput.ToString());
        }
    }
