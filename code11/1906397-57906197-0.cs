    var result = string.Empty;
    
     //first try to get IP address from the forwarded header
                    if (_httpContextAccessor.HttpContext.Request.Headers != null)
                    {
                        //the X-Forwarded-For (XFF) HTTP header field is a de facto standard for identifying the originating IP address of a client
                        //connecting to a web server through an HTTP proxy or load balancer
    
                        var forwardedHeader = _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"];
                        if (!StringValues.IsNullOrEmpty(forwardedHeader))
                            result = forwardedHeader.FirstOrDefault();
                    }
    
                    //if this header not exists try get connection remote IP address
                    if (string.IsNullOrEmpty(result) && _httpContextAccessor.HttpContext.Connection.RemoteIpAddress != null)
                        result = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
