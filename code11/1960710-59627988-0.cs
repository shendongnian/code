    using Microsoft.AspNet.OData;
    using System;
    using System.Web;
    using System.Web.Http.Controllers;
    namespace Backend.api.Process
    {
        public class DecodeFilter : EnableQueryAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var url = actionContext.Request.RequestUri.OriginalString;
                var newUrl = HttpUtility.UrlDecode(url);
                actionContext.Request.RequestUri = new Uri(newUrl);
                base.OnActionExecuting(actionContext);
            }
        }
    }
