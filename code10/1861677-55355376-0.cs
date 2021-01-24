    var counts = new Dictionary<int, int>();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            var number = arr[i, j];
            if (!counts.ContainsKey(number))
            {
                counts[number] = 0;
            }
            counts[number] += 1;
        }
    }
    foreach (var pair in counts)
    {
        if (pair.Value > 1)
        {
            Console.WriteLine(pair.Key);
        }
    }
    // 1
    // 6
