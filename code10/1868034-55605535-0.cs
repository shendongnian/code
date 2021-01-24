    namespace Example.Helper
    {
        public class ValidateUserLoggedIn : ActionFilterAttribute
        {
            /// <summary>
            /// Method for redirect to url first time only
            /// </summary>
            /// <param name="filterContext"></param>
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                try
                {
                    string cookieName = "NotFirstTimeVisit";
                    if (!HttpContext.Current.Request.Cookies.AllKeys.Contains(cookieName))
                    {
                        // first time, add a cookie.
                        HttpCookie cookie = new HttpCookie(cookieName);
                        cookie.Value = "True";
                        HttpContext.Current.Response.Cookies.Add(cookie);
    
                        // You can add your URL here
                        filterContext.Result = new RedirectToRouteResult(
                                                                        new RouteValueDictionary
                                                                        (new
                                                                        {
                                                                            controller = "Department",
                                                                            action = "Index"
                                                                        }
                                                                    ));
                    }
                    base.OnActionExecuting(filterContext);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
    }
