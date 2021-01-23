      public class ImageHandler : IHttpHandler
            {
        
                public void ProcessRequest(HttpContext context)
                {
        
                        if(!string.IsNullOrEmpty(context.Request.QueryString["ImageId"])){
                        try
                        {
                            string ImageId = context.Request.QueryString["ImageId"].ToString(); 
                            ImageDataModel idm = new ImageDataModel();
                            byte[] ImageData = idm.getImageData(ImageId);
        
                            context.Response.ContentType = "image/JPEG";
                            context.Response.OutputStream.Write(ImageData, 0, ImageData.Length); 
        
        
                        }
