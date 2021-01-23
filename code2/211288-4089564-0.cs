            [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "External/Application/{ApplicationGUID}/APIHost/")]
        public Response GetAPIHostName(Request request, string ApplicationGUID)
        {
            Response response = new Response();
            try
            {
                APIHost apiHost = new APIHost
                                              {
                                                  APIHostname = System.Configuration.ConfigurationManager.AppSettings["PlayerAPIHostname"]
                                              };
                response.ResponseBody.APIHost = apiHost;
                response.ResponseHeader.UMResponseCode = (int) UMResponseCodes.OK;
            }
            catch (GUIDNotFoundException guidEx)
            {
                response.ResponseHeader.UMResponseCode = (int)UMResponseCodes.NotFound;
                response.ResponseHeader.UMResponseCodeDetail = guidEx.Message;
            }
            catch (Exception ex)
            {
                UMMessageManager.SetExceptionDetails(request, response, ex);
                if (request != null)
                    Logger.Log(HttpContext.Current, request.ToString(), ex);
                else
                    Logger.Log(HttpContext.Current, "No Request!", ex);
            }
            response.ResponseHeader.HTTPResponseCode = HttpContext.Current.Response.StatusCode;
            return response;
        }
