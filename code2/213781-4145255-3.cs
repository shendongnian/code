    public class ImageHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
    
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                HttpResponse response = context.Response;
    
                response.Clear();
                response.ContentType = "image/png";
    
                Image outputImage = (Load your image here)
                MemoryStream ms = new MemoryStream();
                outputImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.WriteTo(response.OutputStream);
                outputImage.Dispose();
                ms.Close();
       
                response.End();
            }
            catch
            {
                context.Response.End();
            }
        }
    }
