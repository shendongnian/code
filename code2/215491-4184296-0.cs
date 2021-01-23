    #region EncodingType enum
    /// <summary>
    /// Encoding Types.
    /// </summary>
    public enum EncodingType
    {
        ASCII,
        Unicode,
        UTF7,
        UTF8
    }
    #endregion
    
    Then this function: 
    
    #region ByteArrayToString
    /// <summary>
    /// Converts a byte array to a string using Unicode encoding.
    /// </summary>
    /// <param name="bytes">Array of bytes to be converted.</param>
    /// <returns>string</returns>
    public static string ByteArrayToString(byte[] bytes)
    {
        return ByteArrayToString(bytes, EncodingType.Unicode);
    }
    /// <summary>
    /// Converts a byte array to a string using specified encoding.
    /// </summary>
    /// <param name="bytes">Array of bytes to be converted.</param>
    /// <param name="encodingType">EncodingType enum.</param>
    /// <returns>string</returns>
    public static string ByteArrayToString(byte[] bytes, EncodingType encodingType)
    {
        System.Text.Encoding encoding=null;
        switch (encodingType)
        {
            case EncodingType.ASCII:
                encoding=new System.Text.ASCIIEncoding();
                break;   
            case EncodingType.Unicode:
                encoding=new System.Text.UnicodeEncoding();
                break;   
            case EncodingType.UTF7:
                encoding=new System.Text.UTF7Encoding();
                break;   
            case EncodingType.UTF8:
                encoding=new System.Text.UTF8Encoding();
                break;   
        }
        return encoding.GetString(bytes);
    }
    #endregion
