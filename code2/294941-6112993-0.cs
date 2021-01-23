    string FindIt(string inStr)
    {
        for each (string item in inStr.Split(new char [] {';'}))
        {
           string [] eles = item.Split(new char [] {'|'});
             if (eles[0] == "TOFIND")
               return eles[1];
        }
        return "";
    }
