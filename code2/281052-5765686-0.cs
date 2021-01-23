    var num = new List<string>(101);
    for (int i = 0; i < 101 ; i++)
    {
        if (i == 0)
        {
            num.Add(i.ToString());
        }
        else if (i % 10 == 0)
        {
            num.Add("dTen");
        }
        else if (i % 2 == 0)
        {
            num.Add("dTwo");
        }
        else
        {
            num.Add(i.ToString());
        }
    }
