    static void LoadData(string filename, List<string> questions, List<string> answers)
    {
        try
        {
            foreach (var line in File.ReadLines(filename))
            {
                var lineArray = line.Split(',');
                // If this line doesn't contain a comma, skip it
                if (lineArray.Length < 2) continue;
                questions.Add(lineArray[0]);
                answers.Add(lineArray[1]);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
        }
    }
