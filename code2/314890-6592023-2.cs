    public string ReadFileToString(string filePath)
    {
     StreamReader streamReader = new StreamReader(filePath);
     string text = streamReader.ReadToEnd();
     streamReader.Close();
     return text;
    }
