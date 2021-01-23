    public static MvcHtmlString ActionImageLink(this HtmlHelper helper, string imageUrl, string altText, string actionName, string controller, object routeValues, string _imageClass = "", object htmlAttributes = null)
    {
    	var image = new TagBuilder("img");
    	image.MergeAttribute("src", imageUrl);
    	image.MergeAttribute("alt", altText);
    	if (string.IsNullOrEmpty(_imageClass) == false) image.MergeAttribute("class", _imageClass);
    	var link = helper.ActionLink("[replaceme]", actionName, controller, routeValues, htmlAttributes);
    	return new MvcHtmlString(link.ToHtmlString().Replace("[replaceme]", image.ToString(TagRenderMode.SelfClosing)));
    }
    
    public static MvcHtmlString ActionImageLink(this HtmlHelper helper, string imageUrl, string altText, RouteValueDictionary routeValues, string _imageClass = "", object htmlAttributes = null)
    {
    	var image = new TagBuilder("img");
    	image.MergeAttribute("src", imageUrl);
    	image.MergeAttribute("alt", altText);
    	if (string.IsNullOrEmpty(_imageClass) == false) image.MergeAttribute("class", _imageClass);
    	var link = helper.ActionLink("[replaceme]", routeValues, htmlAttributes);
    	return new MvcHtmlString(link.ToHtmlString().Replace("[replaceme]", image.ToString(TagRenderMode.SelfClosing)));
    }
