    private void Merge _Click(object sender, EventArgs e)
    {
    }
    DirectoryInfo directory=new DirectoryInfo("D:\\Images");
    if(directory!=null)
    {
        FileInfo[]files = directory.GetFiles();
        MergeImages(Image);
    }
    
    private void MergeImages(FileInfo[] Image)
    {
        //change the location to store the final image.
        string FImage= @"D:\\Images\\FImage.jpg";
        List imageHeights = new List();
        int nIndex = 0;
        int width = 0;
        foreach (FileInfo file in files)
        {
            Image img = Image.FromFile(file.FullName);
            imageHeights.Add(img.Height);
            width += img.Width;
            img.Dispose();
        }
        imageHeights.Sort();
        int height = imageHeights[imageHeights.Count - 1];
        Bitmap img3 = new Bitmap(width, height);
        Graphics g = Graphics.FromImage(img3);
        g.Clear(SystemColors.AppWorkspace);
        foreach (FileInfo file in files)
        {
            Image img = Image.FromFile(file.FullName);
            if (nIndex == 0)
            {
                g.DrawImage(img, new Point(0, 0));
                nIndex++;
                width = img.Width;
            }
            else
            {
                g.DrawImage(img, new Point(width, 0));
                width += img.Width;
            }
                img.Dispose();
        }
        g.Dispose();
        img3.Save(FImage, System.Drawing.Imaging.ImageFormat.Jpeg);
        img3.Dispose();
        imageLocation.Image = Image.FromFile(FImage);
    }
