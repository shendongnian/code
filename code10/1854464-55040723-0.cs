    if (str.Length > 188)
    {
        str = str.Substring(0,188); 
    }
    else if(str.Length < 188)
    {
        while(str.Length < 188)
        {
            str += "0"; 
        }
    }
