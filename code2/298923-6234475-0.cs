    public class CustomCSSHandler : IHttpHandler 
    {
        public void ProcessRequest(HttpContext ctx) 
        {
            HttpRequest req = ctx.Request;
            string path = req.PhysicalPath;
     
            if (req.UrlReferrer != null && req.UrlReferrer.Host.Length > 0)
            {
                if (CultureInfo.InvariantCulture.CompareInfo.Compare(req.Url.Host, req.UrlReferrer.Host, CompareOptions.IgnoreCase) != 0)
                {
                    path = ctx.Server.MapPath("~/thiswontexist.css");
                }
            }   
            
            if (!File.Exists(path))
            {
                ctx.Response.Status = "File not found";
                ctx.Response.StatusCode = 404;
            }
            else
            {
                ctx.Response.StatusCode = 200;
                ctx.Response.ContentType = "text/css";
                ctx.Response.WriteFile (path);
            }
        }
    }
