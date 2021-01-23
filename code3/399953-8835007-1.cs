    private static string TableRows<T>(HtmlHelper<Table<T>> helper, Table<T> table) where T : IPrivateObject
    {
        var sb = new StringBuilder();
        sb.AppendLine("<table>");
        foreach (var item in table.Items)
        {
            sb.AppendLine("<tr>");
            foreach (var column in table.Columns)
            {
                sb.AppendLine("<td>");
                var viewData = new ViewDataDictionary<T>(item);
                var viewContext = new ViewContext(
                    helper.ViewContext.Controller.ControllerContext,
                    helper.ViewContext.View,
                    new ViewDataDictionary<T>(item),
                    helper.ViewContext.Controller.TempData,
                    helper.ViewContext.Writer
                );
                var viewDataContainer = new ViewDataContainer(viewData);
                var itemHelper = new HtmlHelper<T>(viewContext, viewDataContainer);
                sb.AppendLine("<td>");
                sb.AppendLine(itemHelper.DisplayFor(column.Property));
                sb.AppendLine("</td>");
            }
            sb.AppendLine("</tr>");
        }
        sb.AppendLine("</table>");
        return sb.ToString();    
    }
