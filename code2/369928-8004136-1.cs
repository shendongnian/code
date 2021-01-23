    public string FindFileEnding(string file)
    {
        if (string.IsNullOrEmpty(file))
        {
            // Either throw exception or handle the file here
            throw new ArgumentNullException();
        }
        try
        {
            return file.Substring(file.LastIndexOf('.'));
        }
        catch (Exception ex)
        {
            // Handle the exception here if you want, or throw it to the calling method
            throw ex;
        }
    }
