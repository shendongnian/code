    // http://stackoverflow.com/questions/123336/how-can-you-strip-non-ascii-characters-from-a-string-in-c
    public static string GetAsciiString(string strInputString)
    {
    	string strASCII = System.Text.Encoding.ASCII.GetString(System.Text.Encoding.Convert(System.Text.Encoding.UTF8, System.Text.Encoding.GetEncoding(System.Text.Encoding.ASCII.EncodingName, new System.Text.EncoderReplacementFallback(string.Empty), new System.Text.DecoderExceptionFallback()), System.Text.Encoding.UTF8.GetBytes(strInputString)));
    
    	return strASCII;
    }
    
    
    public static bool IsAscii(string strInputString)
    {
    	//Dim strInputString As String = "Räksmörgås"
    	if ((GetAsciiString(strInputString) == strInputString)) {
    		return true;
    	}
    
    	return false;
    }
