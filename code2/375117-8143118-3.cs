    using System;
    using System.Web;
    
    namespace FileDownloads
    {
        public class Downloads : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                var file = context.Request.QueryString["f"];
                // Assuming all downloadable files are in a folder called "downloads"
                // located at the root of your website/application...
                var path = context.Server.MapPath(
                    string.Format("~/downloads/{0}", file)
                );
                var response = context.Response;
                response.ClearContent();
                response.Clear();
                response.AddHeader("Content-Disposition",
                    string.Format("attachment; filename={0};", file)
                );
                response.WriteFile(path);
                response.Flush();
                response.End();
            }
    
            public bool IsReusable
            {
                get { return false; }
            }
        }
    }
