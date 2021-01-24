    public class TokenAuthorize: ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			//gettting token from headers
			IEnumerable<string> values;
			if (!actionContext.Request.Headers.TryGetValues("Token", out values) || values.Count() > 1)
			{
             //if no token header found in rquest
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
			}
			else
			{
            //here is logic to validate your token
            //if token is not proper than you can set response as unauthorized as above
            }
        }
    }
