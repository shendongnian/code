    using System;
    using System.Web.Http.Controllers;
    using System.Web.Http.OData;
    namespace ODataWebAPI.API
    {
	    public class EnableQueryForExpand : EnableQueryAttribute
	    {
		   public override void OnActionExecuting(HttpActionContext actionContext)
		   {
			   var url = actionContext.Request.RequestUri.OriginalString;
			   var newUrl = ModifyUrl(url);
			   actionContext.Request.RequestUri = new Uri(newUrl);
			   base.OnActionExecuting(actionContext);
	   	   }
		   private string ModifyUrl(string url)
		   {
			   if (!url.Contains("expand"))
			   {
				   if (url.Contains("?$"))
				   {
					   url = url + "&$";
				   }
				   else
				   {
					   url = url + "?$";
				   }
				   url = url + "expand=Category,Supplier";
			   }
			   return url;
		   }
	   }
    }
