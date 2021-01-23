    public static MvcHtmlString DeleteButton( this HtmlHelper helper, string name, string actionName, object htmlAttributes )
    {
         return DeleteButton( helper, name, actionName, null, null, htmlAttributes );
    }
    public static MvcHtmlString DeleteButton( this HtmlHelper helper, string name, string actionName, string controllerName, object routeValues, object htmlAttributes )
    {
         var buttonBuilder = new TagBuilder("button");
         buttonBuilder.SetInnerText( name );
 
         var formBuilder = new TagBuilder("form");
         var urlHelper = new UrlHelper( helper.ViewContext.RequestContext );
         formBuilder.Attributes.Add( "action", urlHelper.Action( actionName, controllerName, routeValues ) )
         formBuilder.Attributes.Add( "method", FormMethod.Post );
         formBuilder.MergeAttributes( new RouteValueDictionary( htmlAttributes ) );
         formBuilder.InnerHtml = buttonBuilder.ToString();
         return new MvcHtmlString( formBuilder.ToString() );
    }
