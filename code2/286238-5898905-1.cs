    private void Zipup()
    {
        string _outputFileName = "Fargle.epub";
        using (FileStream fs = File.Open(_outputFileName, FileMode.Create, FileAccess.ReadWrite ))
        {
            using (var output= new ZipOutputStream(fs))
            {
                var e = output.PutNextEntry("mimetype");
                e.CompressionLevel = CompressionLevel.None;
                byte[] buffer= System.Text.Encoding.ASCII.GetBytes("application/epub+zip");
                output.Write(buffer,0,buffer.Length);
                output.PutNextEntry("META-INF/");  // this will be a directory
                output.PutNextEntry("META-INF/container.xml");
                WriteExistingFile(output, "META-INF/container.xml");
                output.PutNextEntry("OPS/");  // another directory
                output.PutNextEntry("OPS/whatever.xhtml");
                WriteExistingFile(output, "OPS/whatever.xhtml");
                // ...
            }
        }
    }
    private void WriteExistingFile(Stream output, string filename)
    {
        using (FileStream fs = File.Open(_outputFileName, FileMode.Read))
        {
            int n = -1;
            byte[] buffer = new byte[2048];
            while ((n = fs.Read(buffer,0,buffer.Length)) > 0)
            {
                output.Write(buffer,0,n);
            }
        }
    }
