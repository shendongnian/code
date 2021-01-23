              public ActionResult Image2()
        {
            MemoryStream oStream = new MemoryStream();
            using (Bitmap obmp = ImageUtil.RenderImage("Respone.Cache.Setxx calls", 5, DateTime.Now))
            {
                obmp.Save(oStream, ImageFormat.Jpeg);
                oStream.Position = 0;
                Response.Cache.SetCacheability(HttpCacheability.Public);
                Response.Cache.SetMaxAge(TimeSpan.FromMinutes(5));
                return new FileStreamResult(oStream, "image/jpeg");
            }
        }
