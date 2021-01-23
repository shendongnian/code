     public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var cookies = actionContext.Request.Headers.GetCookies("credentials").FirstOrDefault();
                string username = cookies.Cookies.Where(c => c.Name == "username").FirstOrDefault().Value;
                actionContext.Request.Properties.Add("username", username); // so you can access the value from within your actions
            }
