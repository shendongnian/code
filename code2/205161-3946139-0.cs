    public class AreaController : ControllerBase
        {
            private string Area
            {
                get
                {
                    return this.GetType().Namespace.Replace("MySite.Controllers.", "");
                }
            }
            protected override ViewResult View(string viewName, string masterName, object model)
            {
                string controller = this.ControllerContext.RequestContext.RouteData.Values["controller"].ToString();
    
                if (String.IsNullOrEmpty(viewName))
                    viewName = this.ControllerContext.RequestContext.RouteData.Values["action"].ToString();
    
                return base.View(String.Format("~/Views/{0}/{1}/{2}.aspx", Area, controller, viewName), masterName, model);
            }
    
            protected override PartialViewResult PartialView(string viewName, object model)
            {
                string controller = this.ControllerContext.RequestContext.RouteData.Values["controller"].ToString();
    
                if (String.IsNullOrEmpty(viewName))
                    viewName = this.ControllerContext.RequestContext.RouteData.Values["action"].ToString();
    
                PartialViewResult result = null;
    
                result = base.PartialView(String.Format("~/Views/{0}/{1}/{2}.aspx", Area, controller, viewName), model);
    
                if (result != null)
                    return result;
    
                result = base.PartialView(String.Format("~/Views/{0}/{1}/{2}.ascx", Area, controller, viewName), model);
    
                if (result != null)
                    return result;
    
                result = base.PartialView(viewName, model);
    
                return result;
            }
        }
