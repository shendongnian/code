    for (int i = 0; i < list.Count; i++)
    {
        int n = list[i];
        if (n % 2 == 0)
        {
            list.RemoveAt(i--);
        }
    }
