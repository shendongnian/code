    public byte[] GenerateFileData()
    {
        var fileData = new byte[0];
    
        using (var ms = new MemoryStream())
        {
            using (var sw = new StreamWriter(ms))
            {
                Messages.ForEach(x => sw.WriteLine(x)); // Messages is a list of strings in this class
            }
            ms.Flush();
            fileData = ms.ToArray();
        }
    
        return fileData;
    }
