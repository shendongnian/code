    public class Handler : IHttpAsyncHandler {
        public void ProcessRequest(HttpContext context)
        {
        }
        public IAsyncResult BeginProcessRequest(HttpContext context,
                AsyncCallback cb, object extraData)
        {
            IAsyncResult ar = BeginYourLongAsyncProcessHere(cb);
            return ar;
        }
        public void EndProcessRequest(IAsyncResult ar)
        {
            Object result = EndYourLongAsyncProcessHere(ar);
        }
        public bool IsReusable { get { return false; } }
    }
