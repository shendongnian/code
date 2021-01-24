    public byte[] GetZippedFileFromFileList(List<KeyValuePair<string, byte[]>> fileList)
    {
        using (MemoryStream zipStream = new MemoryStream())
        {
            using (ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                foreach (var file in fileList)
                {
                    var zipEntry = zip.CreateEntry(file.Key);
                    using (var writer = new StreamWriter(zipEntry.Open()))
                    {
                        new MemoryStream(file.Value).WriteTo(writer.BaseStream);
                    }
                }
            }
            return zipStream.ToArray();
        }
    }
