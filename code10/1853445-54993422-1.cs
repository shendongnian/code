    using Ionic.Zip;
    using (var s = new MemoryStream(emailAttachment.Body))
    using (ZipFile zip = ZipFile.Read(s))
    {
        foreach (ZipEntry ent in zip)
        {
            string path = Path.Combine(CurrentFileSystem, ent.FileName.FileFullPath())
            using (FileStream file = new FileStream(path, FileAccess.Write))
            {
                ent.Extract(file);
            }   
        }
    }
