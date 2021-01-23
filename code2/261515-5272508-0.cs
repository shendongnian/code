    // Save a thumbnail of the file
    byte[] fileBytes = System.IO.File.ReadAllBytes(savedFileName);
    
    System.Drawing.Image i;
    using (MemoryStream ms = new MemoryStream())
    {
        ms.Write(fileBytes, 0, fileBytes.Length);
        i = System.Drawing.Image.FromStream(ms);
    }
    
    // Create the thumbnail
    System.Drawing.Image thumbnail = i.GetThumbnailImage(135, 150, () => false, IntPtr.Zero);
