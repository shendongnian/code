    public class ImageHandler: IHttpHandler
    {
        public void ProcessRequest (HttpContext context)
        {
             int imageID = -1;
             if (context.Request.QueryString["id"] == null || !int.TryParse( context.Request.QueryString["id"], out imageID) ) 
             {
                 throw new ArgumentException("Invalid or missing image id.");
             }
    
             using (var context = new ImagesDataContext())
             {
                  var image = context.Images.SingleOrDefault( i => i.ID == imageID );
                  if (image != null)
                  {
                       context.Response.ContentType = image.MimeType;
                       context.Response.BinaryWrite( image.Content );
                  }
                  else
                  {
                      // decide how you want to handle an image that isn't found
                  }
             }
    
        }
    
        public bool IsReusable
        {
            get { return false; }
        } 
    }
