    public static Stream CreateOuterZip()
            {
                string fileContents = "Lorem ipsum dolor sit amet";
    
                // Final zip file
                var fs = new FileStream(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SendToClient.zip"), FileMode.OpenOrCreate);
    
                // Create inner zip 1
                var innerZip1 = new MemoryStream();
                using (var archive = new ZipArchive(innerZip1, ZipArchiveMode.Create, true))
                {
                    var file1 = archive.CreateEntry("File1.xml");
                    using (var writer = new BinaryWriter(file1.Open()))
                    {
                        writer.Write(fileContents); // Change fileContents to real XML content
                    }
                    var file2 = archive.CreateEntry("File2.xml");
                    using (var writer = new BinaryWriter(file2.Open()))
                    {
                        writer.Write(fileContents); // Change fileContents to real XML content
                    }
                }
    
                // Create inner zip 2
                var innerZip2 = new MemoryStream();
                using (var archive = new ZipArchive(innerZip2, ZipArchiveMode.Create, true))
                {
                    var file3 = archive.CreateEntry("File3.xml");
                    using (var writer = new BinaryWriter(file3.Open()))
                    {
                        writer.Write(fileContents); // Change fileContents to real XML content
                    }
                    var file4 = archive.CreateEntry("File4.xml");
                    using (var writer = new BinaryWriter(file4.Open()))
                    {
                        writer.Write(fileContents); // Change fileContents to real XML content
                    }
                }
    
                using (var archive = new ZipArchive(fs, ZipArchiveMode.Create, true))
                {
                    // Create inner zip 1
                    var innerZipEntry = archive.CreateEntry("InnerZip1.zip");
                    innerZip1.Position = 0;
                    using (var s = innerZipEntry.Open())
                    {
                        innerZip1.WriteTo(s);
                    }
    
                    // Create inner zip 2
                    var innerZipEntry2 = archive.CreateEntry("InnerZip2.zip");
                    innerZip2.Position = 0;
                    using (var s = innerZipEntry2.Open())
                    {
                        innerZip2.WriteTo(s);
                    }
                }
    
                fs.Close();
                return fs; // The file is written, can probably just close this
            }
