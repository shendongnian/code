        var num = new List<string>();
        for (int n = 0; n < 101; n++)
        {
            if( n % 10 == 0)
            {
               num.Add("dTen");
            }
            else num.Add(n % 2 == 0 ? "dTwo" : n.ToString());
        }
