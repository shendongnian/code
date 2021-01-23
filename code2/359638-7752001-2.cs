    public static int LastIndexOf(this string str, char charToSearch, int repeatCound)
    {
        int index = -1;
        for(int i = str.Length - 1; i >= 0, numfound < repeatCound)
        {
            if(str[i] == charToSearch)
            {
                index = i; 
                numfound++;
            }
        }
    
        return index;
    }
