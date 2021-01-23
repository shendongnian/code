    var lengths = new[] { 4, 6, 4, 7, 9 };
    var parts = new List<string>(lengths.Length);
    // if you're not using .NET4 then use ReadAllLines rather than ReadLines
    foreach (string line in File.ReadLines("YourFile.txt"))
    {
        int index = 0;
        foreach (int length in lengths)
        {
            parts.Add(line.Substring(index, length));
            index += length;
        }
        // do something with "parts" before clearing it ready for the next line
        parts.Clear();
    }
