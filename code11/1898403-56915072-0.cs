    var array = Enumerable.Range(0, 63).Select(i => (double)i).ToArray();
    var splitted = new List<ArraySegment<double>>();
    int offset = 0;
    int count = 8;
    for (int i = 0; i < 6; i++)
    {
        splitted.Add(new ArraySegment<double>(array, offset, count));
        offset += count;
        count++;
    }
    // see what we have
    foreach (var seg in splitted)
        Console.WriteLine(seg.Offset + " " + seg.Count);
    // work with segments
    var segment = splitted[3];
    segment[5] = 555555;
    // the main array has also changed
    Console.WriteLine(string.Join(" ", array));
