    string basefilename = Path.GetFileNameWithoutExtension(entries[0].FileName);
    ZipFile zip = new ZipFile();
    foreach (var entry in entries){
          CrcCalculatorStream reader = entry.OpenReader();
          MemoryStream memstream = new MemoryStream();
          reader.CopyTo(memstream);
          byte[] bytes = memstream.ToArray();
          string newFileName = basefilename + Path.GetExtension(entry.FileName);
          zip.AddEntry(newFileName, bytes);
    }
           
    zip.Save(@"c:\files\" + basefilename + ".zip");
