        [OutputCache(Location = OutputCacheLocation.Any, Duration = 300)]
        public ActionResult Image1()
        {
            MemoryStream oStream = new MemoryStream();
            using (Bitmap obmp = ImageUtil.RenderImage("called with OutputCacheAttribute", 5, DateTime.Now))
            {
                obmp.Save(oStream, ImageFormat.Jpeg);
                oStream.Position = 0;
                return new FileStreamResult(oStream, "image/jpeg");
            }
        }
