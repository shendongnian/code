    int iWidth = 0;
    int iHeight = 0;
    using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap("yourFilePath"))
    {
         iWidth = bmp.Width;
         iHeight = bmp.Height;
    }
