    private void IonicZip()
    {
        string sourcePath = "C:\\pulications\\";
        string fileName = "filename.epub";
    
        // Creating ZIP file and writing mimetype
        using (ZipOutputStream zs = new ZipOutputStream(sourcePath + fileName))
        {
            var o = zs.PutNextEntry("mimetype");
            o.CompressionLevel = CompressionLevel.None;
    
            byte[] mimetype = System.Text.Encoding.ASCII.GetBytes("application/epub+zip");
            zs.Write(mimetype, 0, mimetype.Length);
        }
           
        // Adding META-INF and OEPBS folders including files     
        using (ZipFile zip = new ZipFile(sourcePath + fileName))
        {
            zip.AddDirectory(sourcePath  + "META-INF", "META-INF");
            zip.AddDirectory(sourcePath  + "OEBPS", "OEBPS");
            zip.Save();
        }
    }
