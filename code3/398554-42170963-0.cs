    public static int WordCount(string str)
    {        
        int num=0;
        bool wasInaWord=true;;
                
        if (string.IsNullOrEmpty(str))
        {
            return num;
        }
        
        for (int i=0;i< str.Length;i++)
        {
            if (i!=0)
            {
                if (str[i]==' ' && str[i-1]!=' ')
                {
                    num++;
                    wasInaWord=false;
                }
            } 
                if (str[i]!=' ')
                {
                    wasInaWord=true;                
                }
        }
        if (wasInaWord)
        {
            num++;
        }
        return num;
    }
