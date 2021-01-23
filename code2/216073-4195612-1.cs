    // Or wherever your file is located
    string path = @"C:\MyFile.edf";
    // Pattern to check each line
    Regex pattern = new Regex(@"\[([^\]]*?)\]");
    // Read in lines
    string[] lines = File.ReadAllLines(path);
    // Iterate through lines
    foreach (string line in lines)
    {
       // Check if line matches your format here
       var matches = pattern.Matches(line);
       
       if (matches.Count == 2)
       {
          string value1 = matches[0].Groups[1].Value;
          string value2 = matches[1].Groups[1].Value;
          Console.WriteLine(string.Format("{0} - {1}", value1, value2));
       }
    }
