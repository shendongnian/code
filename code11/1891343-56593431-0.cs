        using System.Linq; 
        using System.Text.RegularExpressions;
        ... 
        string path = @"C:\Users\Precision\Desktop\testing\data.txt";
        Console.WriteLine("Enter CNIC or Phone No");
        string check = Console.ReadLine();
        var records = File
          .ReadLines(path)
          .Where(line => line.Contains(check));
        Regex regex = new Regex(@"(?<name>[^:]+):\s*(?<value>\S*)");
        bool isFirstRecord = true; 
        foreach (string record in records) {
          if (isFirstRecord)
            Console.WriteLine("Data Found Against {0}", check);
          isFirstRecord = false;
          Dictionary<string, string> data = regex
            .Matches(record)
            .Cast<Match>()
            .ToDictionary(match => match.Groups["name"].Value.Trim(),
                          match => match.Groups["value"].Value.Trim(),
                          StringComparer.OrdinalIgnoreCase);
          Console.WriteLine(string.Join(Environment.NewLine, data
            .Select(pair => $"{pair.Key,-11} = {pair.Value}")));  
        }
        // If we haven't read any record 
        if (isFirstRecord) 
          Console.WriteLine("No Data Found");
