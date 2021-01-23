    public class MyToolkitHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            IHttpHandler handler = Toolkit.GetHandler();
            if (handler != null)
            {
                handler.ProcessRequest(context);
            }
        }
    }
