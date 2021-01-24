    Enumerable.Range(1, inputCount * 2).Skip(10).Take(inputCount).ToList().CopyTo(result);
    // 10,11,12,13,14,15,16,17,18,19
    // 20 items as input. skipped 10
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
