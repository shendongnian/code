    var results = new List<string>();
    using (var sr = new StreamReader(filepath, true)) 
    {
        var line = "";
        while ((line=sr.ReadLine()) != null)
        {
            if (line.Contains("Correct") && !line.Contains("Test12")) 
            {
                var res = Regex.Match(line, @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2,}(?:,\d{3}\b)?");
                if (res.Success)
                {
                    results.Add(res.Value);
                }
            }
        }
    }
