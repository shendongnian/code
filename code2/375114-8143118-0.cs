    using System;
    using System.Web;
    
    namespace FileDownloads
    {
        public class Downloads : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                var file = context.Request.QueryString["f"];
    
                var response = context.Response;
                response.ClearContent();
                response.Clear();
                response.AddHeader("Content-Disposition",
                    string.Format("attachment; filename={0};", file)
                );
                response.WriteFile(context.Server.MapPath(string.Format("~/downloads/{0}", file)));
                response.Flush();
                response.End();
            }
    
            public bool IsReusable
            {
                get { return false; }
            }
        }
    }
