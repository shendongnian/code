    var tempFileName = Path.GetTempFileName();
    try
    {
        using (var streamReader = new StreamReader(inptuFileName))
        using (var streamWriter = new StreamWriter(tempFileName))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    streamWriter.WriteLine(line);
            }
        }
        File.Copy(tempFileName, inptuFileName, true);
    }
    finally
    {
        File.Delete(tempFileName);
    }
