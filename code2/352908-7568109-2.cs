    for (int pass = 1; pass < list.Count; pass++)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].CompareTo(list[i + 1]) > 0)
            {
                // Swap
                T temp = list[i];
                list[i] = list[i + 1];
                list[i + 1] = temp;
            }
        }
    }
