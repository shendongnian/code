    public static string Encode(string txt)
    {
        var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(txt);  //8bits per char
        var tmp = Encoding.GetEncoding("utf-16").GetString(bytes); //get a string that uses 16 bits per char
        return tmp;
    }
    public static string Revert(string txt)
    {
         var bytes = Encoding.GetEncoding("utf-16").GetBytes(txt);
         var tmp = Encoding.Default.GetString(bytes);
         return tmp;
    }
