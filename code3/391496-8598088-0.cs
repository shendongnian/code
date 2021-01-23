    public class MyHandler : IHttpHandler, IRequireSessionState
    {
       public bool IsReusable { get { return false; } }
       
       public void ProcessRequest(HttpContext ctx)
       {
           // your code here
       }
    }
