    public static bool IsZipValid()
    {
        try
        {
            string basePath = @"C:\multi-part-zip\";
            List<string> files = new List<string> {
                                    basePath + "somefile.zip.001",
                                    basePath + "somefile.zip.002",
                                    basePath + "somefile.zip.003",
                                    basePath + "somefile.zip.004",
                                    basePath + "somefile.zip.005",
                                    basePath + "somefile.zip.006",
                                    basePath + "somefile.zip.007",
                                    basePath + "somefile.zip.008"
                                };
            using (var zipFile = new ZipArchive(new CombinationStream(files.Select(x => new FileStream(x, FileMode
            {
                // Do whatever you want
            }
        }
        catch(InvalidDataException ex)
        {
            return false;
        }
    
        return true;
    }
