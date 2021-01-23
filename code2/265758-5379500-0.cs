    public static void SaveStarCarCAPImage(int capID, string path)
    {
        byte[] capBinary = Motorpoint2011Data.RetrieveCapImageData(capID, path);
        if (capBinary != null)
        {
            MemoryStream ioStream = new MemoryStream();
            ioStream = new MemoryStream(capBinary);
            // save the memory stream as an image
            // Read in the data but do not close, before using the stream.
            using (Stream originalBinaryDataStream = ioStream)
            {
                path = System.IO.Path.Combine(path, capID + ".jpg");
                Image image = Image.FromStream(originalBinaryDataStream);
                Image resize = image.GetThumbnailImage(500, 375, null, new IntPtr());
                resize.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
