    private static void CreateThumbnail(string[] b, double wid, double hght, bool Isprint)
    {
        string saveAt = "I:\\check";
        foreach (string path in b)
        {
            var directory = new DirectoryInfo(path);
            string outputPath = Path.Combine(saveAt, directory.Name);
            foreach (FileInfo f in directory.GetFiles("*.*", SearchOption.AllDirectories))
            {
                if (f.DirectoryName != directory.FullName)
                {
                    outputPath = Path.Combine(saveAt, directory.Name, f.Directory.Name);
                } 
                Image.GetThumbnailImageAbort myCallback = () => false;
                Image imagesize = Image.FromFile(f.FullName);
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
                if (!Directory.Exists(outputPath))
                {
                    Directory.CreateDirectory(outputPath);
                }
                string fileName = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(f.Name) + ".jpeg");
                Image myThumbnail150 = bitmapNew.GetThumbnailImage((int)newWidth, (int)newHeight, myCallback, IntPtr.Zero);
                myThumbnail150.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
