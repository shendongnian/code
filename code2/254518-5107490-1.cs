    evaluator.Reset();
    
    evaluator.Start();
    for (int run = 0; run < repetitions; run++)
    {
    for (int i = 0; i < original.Rows; i++)
    {
    for (int j = 0; j < original.Cols; j++)
    {
    original.Data[i, j, 0] = 100;
    
    original.Data[i, j, 1] = 40;
    original.Data[i, j, 2] = 243;
    }
    }
    }
    evaluator.Stop();
    Console.WriteLine("Average execution time for {0} iterations \n using Data property: {1}ms\n", repetitions, evaluator.ElapsedMilliseconds / repetitions);
