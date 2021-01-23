    System.Drawing.Image pic = new System.Drawing.Bitmap(sourceFilename);
    System.Drawing.Image thumb = pic.GetThumbnailImage(targetXSize,targetYSize, 
                                 new System.Drawing.Image.GetThumbnailImageAbort(this.GetThumbnailImageAbort), 
                                 IntPtr.Zero);
    thumb.Save(thumbPathName);
