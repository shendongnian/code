    if (str.Length > i+500)
    {
         Response.Write(str.Substring(i, 500));
    }
    else
    {
         Response.Write(str.Substring(i, str.Length-i));
    }
 
