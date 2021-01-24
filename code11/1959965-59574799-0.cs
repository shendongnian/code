    public class IpFilter : AuthorizationFilterAttribute
        {
            string[] allowedIps;
    
            public IpFilter()
            {
                allowedIps = ReadFromConfig(); //You may read from config your allowed ips
            }
    
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                CheckIps(actionContext);
            }
    
            public void CheckIps(HttpActionContext actionContext)
            {
                string requestIpAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(requestIpAddress ))
                {
                   requestIpAddress = HttpContext.Current.Request.UserHostAddress;
                }
    
                if(string.IsNullOrEmpty(requestIpAddress))
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);
    
    
                foreach (var ip in allowedIps)
                {
                    if (requestIpAddress == ip.Trim())
                        return;
                }
    
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                    new { Message = "Unauthorized" });
            }
        }
