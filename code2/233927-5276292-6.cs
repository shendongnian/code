             public void ProcessRequest(HttpContext context)
        {
            using (var image = ImageUtil.RenderImage("called from IHttpHandler direct", 5, DateTime.Now))
            {
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.Cache.SetMaxAge(TimeSpan.FromMinutes(5));
                context.Response.ContentType = "image/jpeg";
                image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            }            
        }
