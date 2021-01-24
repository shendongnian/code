    String str = "asdafahxlkax"; 
    char[] chars = str.ToCharArray();
    
    int counter = 0;
    for (int i = 0; i < chars.Length; i++)
    {
        if(chars[i] == 'a')
        {
            counter++;
        }
        if(chars[i] == 'x')
        {
            if(counter == 3)
            {
                // success
            }
            else
            {
                // fail
            }
        }
    }
