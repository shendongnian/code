    using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
    {
        if (!isf.DirectoryExists("Images"))
        {
            isf.CreateDirectory("Images");
        }
        IsolatedStorageFileStream fstream = isf.CreateFile(string.Format("Images\\{0}.jpg",imageNumber));
     
        WriteableBitmap wbmp = new WriteableBitmap(image);
        Extensions.SaveJpeg(wbmp, fstream, wbmp.PixelWidth, wbmp.PixelHeight, 0, 100);
        fstream.Close();
    }
