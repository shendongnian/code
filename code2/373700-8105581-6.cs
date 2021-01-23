    public static MvcHtmlString DeleteButton(this HtmlHelper helper, string name, string actionName, object routeValues)
    {
    	return DeleteButton(helper, name, actionName, null, routeValues, null);
    }
    
    public static MvcHtmlString DeleteButton(this HtmlHelper helper, string name, string actionName, string controllerName, object routeValues, object htmlAttributes)
    {
    	using (helper.BeginForm(actionName, controllerName, routeValues, FormMethod.Post, htmlAttributes))
    	{
    		var response = helper.ViewContext.HttpContext.Response;
    		var builder = new TagBuilder("button");
    		builder.SetInnerText(name);
    		response.Write(builder.ToString(TagRenderMode.Normal));
    	}
    	return MvcHtmlString.Create("");
    }
