    string str = string.Empty;
    using (Stream stream = System.IO.File.Open("Logs/log.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        using (StreamReader streamReader = new StreamReader(stream))
        {
            str = streamReader.ReadToEnd();
            //.....
        }
    }
