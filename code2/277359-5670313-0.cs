    var currentChoice = "";
    foreach (var path in paths)
    {
        for (int i = path.Length; i > 0; i--)
        {
            var candidate = path.Substring(0, i);
            if (i > currentChoice.Length &&
                paths.Count(p => p.StartsWith(candidate)) > 1)
                currentChoice = candidate;
            else
                break;
        }
    }
    Console.WriteLine(currentChoice);
