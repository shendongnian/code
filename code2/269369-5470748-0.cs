    public void CreateThumbnail(string[] b, double wid, double hght, bool Isprint)
    {
        string[] path;
        path = new string [64];
        path = b;
        string saveath = "i:\\check\\a test\\";
        for (int i = 0; i < b.Length; i++)
        {
            DirectoryInfo dir = new DirectoryInfo(path[i]);
            string dir1 = dir.ToString();
            dir1 = dir1.Substring(dir1.LastIndexOf("\\"));
        FileInfo[] files1 = dir.GetFiles();
        foreach (FileInfo f in files1)
        {
            string gh = f.ToString();
            try
            {
                System.Drawing.Image myThumbnail150;
                System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                System.Drawing.Image imagesize = System.Drawing.Image.FromFile(f.FullName);
                Bitmap bitmapNew = new Bitmap(imagesize);
                double maxWidth = wid;
                double maxHeight = hght;
                int w = imagesize.Width;
                int h = imagesize.Height;
                // Longest and shortest dimension 
                int longestDimension = (w > h) ? w : h;
                int shortestDimension = (w < h) ? w : h;
                // propotionality  
                float factor = ((float)longestDimension) / shortestDimension;
                // default width is greater than height    
                double newWidth = maxWidth;
                double newHeight = maxWidth / factor;
                // if height greater than width recalculate  
                if (w < h)
                {
                    newWidth = maxHeight / factor;
                    newHeight = maxHeight;
                }
                myThumbnail150 = bitmapNew.GetThumbnailImage((int)newWidth, (int)newHeight, myCallback, IntPtr.Zero);
                string ext = Path.GetExtension(f.Name);
                if (!Directory.Exists(saveath + dir1))
                {
                    Directory.CreateDirectory(saveath + dir1);
                    myThumbnail150.Save(saveath + dir1 + "\\" + f.Name.Replace(ext, ".Jpeg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if(Directory.Exists(saveath+dir1))
                {
                    myThumbnail150.Save(saveath + dir1+" \\"+ f.Name.Replace(ext, ".Jpeg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("something went wrong" + ex.ToString());
            }
        }
    }
}
