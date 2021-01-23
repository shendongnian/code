    public class Ping : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.BufferOutput = false;
            context.Response.ContentType = "text/plain";
            context.Response.WriteLine("HELLO"); // <-- data is sent immediately
            System.Threading.Thread.Sleep(10000);
        }
    }
