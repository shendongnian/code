    public static MvcHtmlString EditUserLinkForModel<UserListItem>(this HtmlHelper<UserListItem> htmlHelper)
    {
       var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
       return urlHelper.Action("Edit", 
                               "UserController", 
                               new { id = htmlHelper.ViewData.Model.UserId });
    }
