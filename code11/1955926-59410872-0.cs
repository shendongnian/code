        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Headers.GetValues("UserToken").FirstOrDefault() == null)
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                    {
                        ReasonPhrase = "Http request doesnot have the UserToken header"
                    };
                }
                else
                {
                    string username = string.Empty, password = string.Empty;
                    var userToken = actionContext.Request.Headers.GetValues("UserToken").FirstOrDefault();
                    var token = FormsAuthentication.Decrypt(userToken);
                    if (token.Expired)
                    {
                        actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                        {
                            ReasonPhrase = "Invalid User Token"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = ex.Message
                };
            }
        }       
    } 
