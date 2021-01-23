    List<string> seen = new List<string>();
        string line = string.Empty;
        while ((line = file.ReadLine()) != null)
        {
            foreach (Match match in Regex.Matches(line, @"(\w*)\.\."))
            {
                if (!seen.Contains(line))
                {
                    Console.WriteLine(line);
                    seen.Add(line);
                }
            }
        }
