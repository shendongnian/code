    using (Graphics graphics = Graphics.FromImage(target))
    {
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
        graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
        graphics.Clear(ColorTranslator.FromHtml("#F4F6F5"));
        graphics.DrawImage(bmp, 0, 0, 145, 145);
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            target.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);                    
            memoryStream.WriteTo(context.Response.OutputStream);
        }
    }
