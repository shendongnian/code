    using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
    {
        if (!isf.DirectoryExists("Images"))
        {
            isf.CreateDirectory("Images");
        }
        IsolatedStorageFileStream fstream = isf.CreateFile(string.Format("Images\\{0}.jpg",imageNumber));
     
        WriteableBitmap wb = new WriteableBitmap(image);
        Extensions.SaveJpeg(wb, fstream, wb.PixelWidth, wb.PixelHeight, 0, 100);
        fstream.Close();
    }
