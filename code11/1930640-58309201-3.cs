    static void Main(string[] args)
    {
        var inputFile = @"f:\private\temp\temp.txt";
        var outputFile = @"f:\private\temp\temp2.txt";
        var linesToDisplay = new[] {2, 4, 4, 1};
        var maxLineNumber = linesToDisplay.Max();
        var fileLines = new Dictionary<int, string>(linesToDisplay.Distinct().Count());
        // Start lineNumber at 1 instead of 0
        int lineNumber = 1;
        // Just read up to the largest line number we need 
        // and save the lines we care about in our dictionary
        foreach (var line in File.ReadLines(inputFile))
        {
            if (linesToDisplay.Contains(lineNumber))
            {
                fileLines[lineNumber] = line;
            }
            // Increment our lineNumber and break if we're done
            if (++lineNumber > maxLineNumber) break;
        }
        // Write the output to our file
        File.WriteAllLines(outputFile, linesToDisplay.Select(line => fileLines[line]));
        GetKeyFromUser("\n\nDone! Press any key to exit...");
    }
