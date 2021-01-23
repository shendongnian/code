    Image<Bgr, Byte> original = newImage<Bgr, byte>(1024, 768);
        Stopwatch evaluator = newStopwatch(); 
        int repetitions = 20;
        Bgr color = newBgr(100, 40, 243);
        
        evaluator.Start();
        for (int run = 0; run < repetitions; run++)
        {
        for (int j = 0; j < original.Cols; j++)
        {
        for (int i = 0; i < original.Rows; i++)
        {
        original[i, j] = color;
        }
        }
        }
        evaluator.Stop();
        Console.WriteLine("Average execution time for {0} iteration \n using column per row access: {1}ms\n", repetitions, evaluator.ElapsedMilliseconds / repetitions);
 
