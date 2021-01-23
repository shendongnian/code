    public void checkDatas(Object o)
    {
        if (o is Toto)
        {
           (o as Toto).test1 = 0;
        }
    
        if (o is Titi)
        {
           (o as Titi).testA = "";
        }
    }
