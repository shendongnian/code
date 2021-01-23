    if (file != null && file.ContentLength > 0)
    {
        var fileName = Path.GetFileName(file.FileName);
        // TODO: adjust the filenames here
        var path = Path.Combine(Server.MapPath("~/"), fileName);
        using (var input = new Bitmap(file.InputStream))
        {
            int width; 
            int height; 
            if (input.Width > input.Height) 
            { 
                width = 128; 
                height = 128 * input.Height / input.Width; 
            } 
            else 
            { 
                height = 128; 
                width = 128 * input.Width / input.Height; 
            }
            using (var thumb = new Bitmap(width, height))
            using (var graphic = Graphics.FromImage(thumb))
            {
                graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphic.DrawImage(input, 0, 0, width, height);
                using (var output = System.IO.File.Create(path))
                {
                    thumb.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
    }
