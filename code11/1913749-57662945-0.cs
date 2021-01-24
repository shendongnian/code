    public class YourApiController : ApiController {
    	public HttpResponseMessage YourActionName() {
    	    var request = new HttpContextWrapper(CurrentContext).Request;
    		...
    	}
    }
    public class YourAuditHandler : DelegatingHandler {
    	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
    	    string ipAddress = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "0.0.0.0";
    		...
    	}
    }
