    Bitmap bm;
    using (ShellFile shellFile = ShellFile.FromFilePath(filePath))
    {
        ShellThumbnail thumbnail = shellFile.Thumbnail;
    
        thumbnail.FormatOption = ShellThumbnailFormatOption.ThumbnailOnly;
    
        try
        {
            bm = thumbnail.MediumBitmap;
        }
        catch // errors can occur with windows api calls so just skip
        {
            bm = null;
        }
        if (bm == null)
        {
            thumbnail.FormatOption = ShellThumbnailFormatOption.IconOnly;
            bm = thumbnail.MediumBitmap;
            // make icon transparent
            bm.MakeTransparent(Color.Black);
        }
    }
