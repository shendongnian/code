	public class HttpForbiddenResult : HttpStatusCodeResult
    {
        public HttpForbiddenResult()
            : this(null)
        {
        }
        // Forbidden is equivalent to HTTP status 403, the status code for forbidden
        // access. Other code might intercept this and perform some special logic. For
        // example, the FormsAuthenticationModule looks for 401 responses and instead
        // redirects the user to the login page.
        public HttpForbiddenResult(string statusDescription)
            : base(HttpStatusCode.Forbidden, statusDescription)
        {
        }
	}
	
