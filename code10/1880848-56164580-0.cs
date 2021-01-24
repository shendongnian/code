    public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                var logFileName = SetLogInfo("JavaScriptBasicAuth");
                try
                {
                    if (!HttpContext.Current.Request.HttpMethod.Equals("OPTIONS"))
                    {
                        var basicAuth = HttpContext.Current.Request.Headers["Authorization"];
                        if (basicAuth != null)
                        {
                            string[] separator = basicAuth.Split(' ');
                            BasicAuthenticationBehaviorAttribute basicauth = new BasicAuthenticationBehaviorAttribute();
                            if (!basicauth.ValidateBasicAuth(separator[1]))
                            {
                                throw new WebFaultException(HttpStatusCode.Unauthorized);
                            }
                        }
                        else
                        {
                            FileLogger.LogError("401 (Unauthorized) Error - " + "You are not authorized to perform this operation. Please contact administrator.", LOG_SUB_DIRECTORY, logFileName);
                            throw new WebFaultException(HttpStatusCode.Unauthorized);
                        }
    			}
    		}
