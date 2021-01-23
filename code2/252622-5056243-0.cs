    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var id = context.Request["id"];
            byte[] imageData = FetchImageFromDb(id);
            context.Response.ContentType = "image/png";
            context.Response.OutputStream.Write(imageData, 0, imageData.Length);
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
