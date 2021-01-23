    public static string GetCommonDocumentsFolder()
    {
        StringBuilder sb = new StringBuilder();
        int retVal = SHGetFolderPath(IntPtr.Zero,
                                     CSIDL_COMMON_DOCUMENTS | CSIDL_FLAG_CREATE,
                                     IntPtr.Zero,
                                     0,
                                     sb);
        Debug.Assert(retVal >= 0);  // assert that the function call succeeded
        return sb.ToString();
    }
