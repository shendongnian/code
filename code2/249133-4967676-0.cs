    byte[] buffer = null;
    System.Drawing.Image newImg = img.GetThumbnailImage(width, height, null, new System.IntPtr());
    using (MemoryStream ms = new MemoryStream()) {
        newImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
    }
    buffer = ms.ToArray();
