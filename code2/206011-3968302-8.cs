    private static bool LineHasCorrectLength(string line, int expectedLineLength)
    {
        return line.Length == expectedLineLength;
    }
    
    // usage:
    using (StreamReader reader = File.OpenText("thefile.txt"))
    {
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (LineHasCorrectLength(line, 94))
            {
                // add to output
            }
        }
    }
