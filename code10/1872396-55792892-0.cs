    var result = new int[] { 5, 3, 1, 4, 2 }.OrderBy(item =>
    {
        Thread.Sleep(500);
        Console.WriteLine(item);
        return item;
    });
    Console.WriteLine(String.Join(", ", result));
