    <link rel="Stylesheet" href="CustomCSSHandler.ashx?file=site.css" />
    public class CustomCSSHandler : IHttpHandler 
    {
        public void ProcessRequest(HttpContext ctx) 
        {
            HttpRequest req = ctx.Request;
            //Get the file from the query stirng
            string file = req.QueryString["file"];
            //Find the actual path
            string path = ctx.Server.MapPath(file); //Might need to modify location of css
            
            //Limit to only css files
            if(Path.GetExtension(path) != ".css")
                ctx.Response.End();
            if (req.UrlReferrer != null && req.UrlReferrer.Host.Length > 0)
            {
                if (CultureInfo.InvariantCulture.CompareInfo.Compare(req.Url.Host, req.UrlReferrer.Host, CompareOptions.IgnoreCase) != 0)
                {
                    path = ctx.Server.MapPath("~/thiswontexist.css");
                }
            }   
            //Make sure file exists
            if(!File.Exists(path))
            {
                ctx.Response.Status = "File not found";
                ctx.Response.StatusCode = 404;
                ctx.Response.End(); 
            }           
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/css";
            ctx.Response.WriteFile(path);
        }
    }
