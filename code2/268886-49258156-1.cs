    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    
    namespace YourNamespace{        
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
        public class AuthorizeCustom : ActionFilterAttribute {
            public override void OnActionExecuting(ActionExecutingContext context) {
                if (YourAuthorizationCheckGoesHere) {				
    				string area = "";// leave empty if not using area's
    				string controller = "ControllerName";
    				string action = "ActionName";
    				var urlHelper = new UrlHelper(context.RequestContext);					
    				if (context.HttpContext.Request.IsAjaxRequest()){ // Check if Ajax
    					if(area == string.Empty)
    						context.HttpContext.Response.Write($"<script>window.location.reload('{urlHelper.Content(System.IO.Path.Combine(controller, action))}');</script>");
    					else
    						context.HttpContext.Response.Write($"<script>window.location.reload('{urlHelper.Content(System.IO.Path.Combine(area, controller, action))}');</script>");
    				} else   // Non Ajax Request                      
    					context.Result = new RedirectToRouteResult(new RouteValueDictionary( new{ area, controller, action }));				
    			}
    			base.OnActionExecuting(context);
            }
        }
    }
