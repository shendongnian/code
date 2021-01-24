    private static void Search(string[] input)
    {
        string datafile = @"C:\Users\User\Documents\text.txt";
        string inputfile = @"C:\Users\User\Documents\input.txt";
        string outputfile = @"C: \Users\User\Documents\output.txt";
        string[] parameters = System.IO.File.ReadAllLines(inputfile);
        string[] data = System.IO.File.ReadAllLines(datafile);
        var index = new Dictionary<string, int>();
        for (int i = 0; i < data.Length - 1; i += 2)
        {
            string currentline = data[i];
            string[] splitline = currentline.Split(' ');
            index[splitline[0].Trim('>')] = i;
        }
        foreach(var p in parameters)
        {
            if (index.ContainsKey(p))
              Console.WriteLine($"Found {p} at line {index[p]}");
            else 
              Console.WriteLine($"File doesn't contain {p}");
        }
    }
