    char[] items = { 'A', 'A', 'A', 'B', 'B', 'A', 'B', 'B', 'C', 'B' };
    for (int i = 0; i < items.Length; i++)
    {
        if (i == 0)
        {
            // in case of the first element you only have to validate against the next
            if (items[i] != items[i + 1])
                Console.WriteLine(i + 1);
        }
        else if (i == items.Length - 1)
        {
            // in case of the last element you only have to validate against the previous       
            if (items[i] != items[i - 1])
                Console.WriteLine(i + 1);
        }
        else
        {
            // validate against previous and next element
            if (items[i] != items[i - 1] && items[i] != items[i + 1])
                Console.WriteLine(i + 1);
        }
    }
