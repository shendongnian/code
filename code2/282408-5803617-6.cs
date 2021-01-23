    public bool CheckFileType(string FileName)
    {
        if (FileName == null)
        {
            return false;
        }
        if (FileName.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0)
        {
            return false;
        }
        // Your original method goes here
    }
