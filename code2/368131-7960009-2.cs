    using (var orig = ZipFile.Read("C:\\whatever\\OriginalArchive.zip"))
    {
        using (var smaller = new ZipFile())
        {
          foreach (var name in entriesToKeep) 
          { 
             var ms = new MemoryStream();
             orig[name].Extract(ms); // extract into stream
             ms.Seek(0,SeekOrigin.Begin);
             smaller.AddEntry(name,ms);
          }
          smaller.Save("C:\\location\\of\\SmallerZip.zip");
        }   
    }
