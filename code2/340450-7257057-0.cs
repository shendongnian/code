    public class OuputCaptchaImageHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void ProcessRequest(HttpContext context)
        {
            string imagePath =
                    context.Server.MapPath(@"~\Images\1.gif");
            Bitmap bitmap = new Bitmap(imagePath);
            context.Response.ContentType = "image/gif";
            bitmap.Save(context.Response.OutputStream, ImageFormat.Gif);
            bitmap.Dispose();              
        }
    }
