foreach (var row in values)
{
    var length = 0;
    foreach (var cell in row)
    {
        Console.Write($"{cell}");
        length++;
        if (length < row.Count)
        {
            Console.Write(", ");
        }
    }
    Console.WriteLine();
}
