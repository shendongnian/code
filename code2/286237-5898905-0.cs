    private void Zipup()
    {
        using (FileStream fs raw = File.Open(_outputFileName, FileMode.Create, FileAccess.ReadWrite ))
        {
            using (var output= new ZipOutputStream(fs))
            {
                var e = output.PutNextEntry("mimetype");
                e.Compression = CompressionLevel.None;
                byte[] buffer= System.Text.Encoding.ASCII.GetBytes("application/epub+zip");
                output.Write(buffer,0,buffer.Length);
                 ...
            }
        }
    }
