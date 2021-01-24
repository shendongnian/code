    int inputCount = 10;
    int[] result = new int[inputCount];
    Enumerable.Range(1, inputCount / 2).Take(inputCount).ToList().CopyTo(result);
    // 1,2,3,4,5,0,0,0,0,0
    // 5 items as input
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
    Enumerable.Range(1, inputCount * 2).Take(inputCount).ToList().CopyTo(result);
    // 1,2,3,4,5,6,7,8,9
    // 20 items as input
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
