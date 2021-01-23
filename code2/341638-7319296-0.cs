    public static object CategoryEdit(this UrlHelper urlHelper, string categoryId)
    {
       return new { controller = "Category", action = "Edit", id = categoryId };
    }
    
    column.Bound(x => x.Id)
       .ClientTemplate("<a href=\"" + Url.RouteUrl(Url.CategoryEdit("<#= Id #>")) + "\">Edit</a>")
       .Title("Action")
       .Width(50);
