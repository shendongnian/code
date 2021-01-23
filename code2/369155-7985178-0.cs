    public void ProcessRequest (HttpContext context) {
        TimeSpan refresh = new TimeSpan(168, 0, 0);
        HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.Add(refresh));
        HttpContext.Current.Response.Cache.SetMaxAge(refresh);
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Public);
        HttpContext.Current.Response.Cache.SetValidUntilExpires(true);
        string dir = HttpContext.Current.Request.QueryString["dir"];
        string img = HttpContext.Current.Request.QueryString["img"];
        bool force = HttpContext.Current.Request.QueryString["force"] == "yes";
        double w = 0;
        double h = 0;
        string path = null;
        Image orig = null;
        Image thumb = null;
        
        //make sure we have a directory and image filename
        if (string.IsNullOrEmpty(dir))
            return;
        
        //make sure that we allow access to that directory, could do some extra sneaky security stuff here if we had to... (only accept a DirectoryID so the user doesn't know the actual path)
        switch (dir)
        {
            case "user":
                dir = "assets/images/users";
                if (string.IsNullOrEmpty(img) || img == "undefined") img = "0.jpg";
                break;
                break;
            case "icon":
                dir = "assets/images/icons";
                break;
            default:
                dir = "assets/images";
                break;
        }
        //make sure that the image filename is just a filename
        if (img.IndexOf("/") > -1 | img.IndexOf("\\") > -1)
            return;
        //make sure the image exists
        path = HttpContext.Current.Server.MapPath("~/" + dir + "/" + img);
        if (System.IO.File.Exists(path))
        {
            orig = Image.FromFile(path);
        }
        else
        {
            return;
        }
        
        //if there is a max width or height
        if (double.TryParse(HttpContext.Current.Request.QueryString["w"], out w) | double.TryParse(HttpContext.Current.Request.QueryString["h"], out h))
        {
            //thumb is the resized image
            double s = 1;
            if (w > 0 & h > 0)
            {
                double ratio = h / w;
                if (orig.Height / (double)orig.Width > ratio)
                {
                    if (orig.Height > h)
                    {
                        if (force)
                            s = w / (double)orig.Width;
                        else
                            s = h / (double)orig.Height;
                    }
                }
                else
                {
                    if (orig.Width > w)
                    {
                        if (force)
                            s = h / (double)orig.Height;
                        else
                            s = w / (double)orig.Width;
                    }
                }
            }
            else if (w > 0)
            {
                if (orig.Width > w)
                {
                    s = w / (double)orig.Width;
                }
            }
            else if (h > 0)
            {
                if (orig.Height > h)
                {
                    s = h / (double)orig.Height;
                }
            }
            
            //double flip gets it to lose the embedded thumbnail
            //http://www.4guysfromrolla.com/articles/012203-1.2.aspx
            orig.RotateFlip(RotateFlipType.Rotate180FlipNone);
            orig.RotateFlip(RotateFlipType.Rotate180FlipNone);
            
            thumb = orig.GetThumbnailImage(Convert.ToInt32(orig.Width * s), Convert.ToInt32(orig.Height * s), null, IntPtr.Zero);
            if (force && w > 0 & h > 0)
                thumb = cropImage(thumb, (int)w, (int)h);
        }
        else
        {
            //thumb is the image at it's original size
            thumb = orig;
        }
        HttpContext.Current.Response.ContentType = "image/jpeg";
        thumb.Save(HttpContext.Current.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
    }
    private Image cropImage(Image img, int w, int h)
    {
        if (w > img.Width && h > img.Height)
            return img;
        Rectangle cropArea = new Rectangle((img.Width - w) / 2, (img.Height - h) / 2, w, h);
        Bitmap bmpImage = new Bitmap(img);
        Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        return (Image)(bmpCrop);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
