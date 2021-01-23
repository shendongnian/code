    for (int i = 0; i < LoadedImgs.Length; i++)
    {
        info = new FileInfo(LoadedImgs[i].origImgFullPath);
        double sizeMB = Math.Round(((double)info.Length / 1048576.0), MidpointRounding.AwayFromZero);
        if (sizeMB > (double)numImgMaxSize.Value)
        {
            Bitmap bmpOrigImg = new Bitmap(LoadedImgs[i].origImgFullPath);
            Bitmap bmpResizeImg = null;
            bmpResizeImg = ImageUtilities.Resize(bmpOrigImg, sizeMB);
            #region Save the resized image over the original
            bmpOrigImg.Dispose();                        
            bmpResizeImg.Save(LoadedImgs[i].origImgFullPath);
            bmpResizeImg.Dispose();
            #endregion
         }
    }
