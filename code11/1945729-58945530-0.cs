    static int Add(int nb1, int nb2)
    {
        int sum = 0;
        for (int i = nb1; i < nb2; i++)
        {
            if (i % 2 == 0)
            {
                sum = sum + i;
            }
        }
        return sum;
    }
