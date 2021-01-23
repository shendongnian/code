    public class avatar : IHttpHandler, System.Web.SessionState.IRequiresSessionState {
        
        public void ProcessRequest (HttpContext context) {
            string path = "/a/path/to/someplace/";
            if (context.Request.Files.Count > 0)
            {
                int chunk = context.Request["chunk"] != null ? int.Parse(context.Request["chunk"]) : 0;
                string fileName = context.Request["name"] != null ? context.Request["name"] : string.Empty;
    
                HttpPostedFile fileUpload = context.Request.Files[0];
    
                var uploadPath = path;
                using (var fs = new FileStream(Path.Combine(uploadPath, fileName), chunk == 0 ? FileMode.Create : FileMode.Append))
                {
                    var buffer = new byte[fileUpload.InputStream.Length];
                    fileUpload.InputStream.Read(buffer, 0, buffer.Length);
    
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
    
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    
    }
