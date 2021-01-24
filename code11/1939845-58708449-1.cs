    for (int i = 0; i < crossover.Length; i++)
    {
        // This may be what you were missing - we need to instantiate a new List first
        crossover[i] = new List<double>();
        for (int j = 0; j < selection[i].Count / 2; j++)
        {
            crossover[i].Add(selection[i][j]);
        }
    }
