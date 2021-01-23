    public String strip2ndchar(string text)
    {
    string final="";
    int i = 0;
    foreach (char a in text.ToCharArray())
    {
       if (i % 2 == 0)
           final += a;
       i++;
    }
    return final;
    }
