    char separator = ' ';
    int length = 10;
    var splitted = paragraph.Split(separator);
    List<string[]> arrays = new List<string[]>();
    for (int i = 0; i < splitted.Length / length + 1; i++)
    {
        arrays.Add(splitted.Where((x, y) => y >= i * length && y < (i + 1) * length)
            .Select( word => word + separator).ToArray());
    }
    foreach (var arr in arrays)
    {
        foreach (var cell in arr)
        {
            Console.Write(cell);
        }
        Console.WriteLine();
    }
