    private static void CreateThumbnail(string[] b, double wid, double hght, bool Isprint)
    {
        string saveAt = "D:\\check";
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
                if (!Directory.Exists(outputPath))
                {
                    Directory.CreateDirectory(outputPath);
                }
                using (Image imagesize = Image.FromFile(f.FullName))
                using (Bitmap bitmapNew = new Bitmap(imagesize))
                {
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
                    string fileName = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(f.Name) + ".jpeg");
                    bitmapNew.GetThumbnailImage((int)newWidth, (int)newHeight, () => false, IntPtr.Zero)
                        .Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
    }
