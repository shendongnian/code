    int pos = 0
    int limit = 80
    while (true)
    {
        StringBuilder line  = new StringBuilder(limit);
        for(int i = 0; i < limit; i++)
        {
            if (i = pos)
            {
                line.Append("A");
            }
            else
            {
                line.Append(" ");
            }
        }
        Console.WriteLine(line.ToString());
        if (i = (limit - 1))
        {
            limit = 0;
        }
        else
        {
            limit++;
        }
    }
