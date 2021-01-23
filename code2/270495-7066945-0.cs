    using System.IO;
    using ICSharpCode.SharpZipLib.Zip;
    public void BeginZipUpdate()
        {
            _memoryStream = new MemoryStream(200);
            _zipOutputStream = new ZipOutputStream(_memoryStream);
        }
    public void EndZipUpdate()
        {
            _zipOutputStream.Finish();
            _zipOutputStream.Close();
            _zipOutputStream = null;
        }
    //Entry name could be 'somefile.txt' or 'Assemblies\MyAssembly.dll' to indicate a folder.
    //Unsure where you'd be getting your file, I'm reading the data from the database.
    public void AddEntry(string entryName, byte[] bytes)
        {
            ZipEntry entry = new ZipEntry(entryName);
            entry.DateTime = DateTime.Now;            
            entry.Size = bytes.Length;            
            _zipOutputStream.PutNextEntry(entry);
            _zipOutputStream.Write(bytes, 0, bytes.Length);
            _zipOutputStreamEntries.Add(entryName);
        }
