    var lengths = new[] { 4, 6, 4, 7, 9 };
    var parts = new string[lengths.Length];
    // if you're not using .NET4 or above then use ReadAllLines rather than ReadLines
    foreach (string line in File.ReadLines("YourFile.txt"))
    {
        int startPos = 0;
        for (int i = 0; i < lengths.Length; i++)
        {
            parts[i] = line.Substring(startPos, lengths[i]);
            startPos += lengths[i];
        }
        // do something with "parts" before moving on to the next line
    }
