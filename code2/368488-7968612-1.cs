    public class HttpContextBaseWrapper : IHttpContextBaseWrapper
    {
       public HttpRequestBase Request {get{return HttpContext.Current.Request;}}
       public HttpResponseBase Response {get{return HttpContext.Current.Response;}}
       //and anything else you need
    }
