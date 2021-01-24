    List<(float, float)> xyvertices = new List<(float, float)>();
    xyvertices.Add((2, 4));
    for (int a = 1; a < 6; a++)
    {
        xyvertices.Add((a+1,a+3));
    }
    
    xyvertices = xyvertices.Distinct().ToList();
    Console.WriteLine("count:" + xyvertices.Count + "\n");
    for (int i = 0; i < xyvertices.Count; i++)
    {
        Console.WriteLine(xyvertices[i]);
        Console.WriteLine();
    }
