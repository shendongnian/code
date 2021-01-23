    public class UserImage : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            // Get the stream from the database
            var image = System.Drawing.Image.FromStream(stream);
            image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        }
    }
