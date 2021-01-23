    public static long mGetFileLength(string strFilePath)
    {
        if (!string.IsNullOrEmpty(strFilePath))
        {
            System.IO.FileInfo info = new System.IO.FileInfo(strFilePath);
            return info.Length;
        }
    
        return 0; 
    }
