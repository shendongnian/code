    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                int programId = 0;
                if (int.TryParse(id, out programId))
                {
                    // Get the BLOB image from the database
                    var attachment = GetAttachmentImage(programId);
                    if (attachment != null)
                    {
                        context.Response.ContentType = "image/jpeg";
                        context.Response.BinaryWrite(attachment);
                    }
                }
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
