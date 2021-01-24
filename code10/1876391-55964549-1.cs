    public class FileUploadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string extention = System.IO.Path.GetExtension(file.FileName);
                    string fileName = file.FileName.Replace(extention, "") + Guid.NewGuid() + extention;
                    string fname = context.Server.MapPath("~/FolderName/" + fileName);
                    file.SaveAs(fname);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(fileName);
                }
            }
        }
    }
