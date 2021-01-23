    private string UnicodeToUTF8(string strFrom)
    {
        byte[] bytSrc;
        byte[] bytDestination;
        string strTo = String.Empty;
    
        bytSrc = Encoding.Unicode.GetBytes(strFrom);
        bytDestination = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, bytSrc);
        strTo = Encoding.ASCII.GetString(bytDestination);
    
        return strTo;
    }
