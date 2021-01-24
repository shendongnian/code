    var input = @"""Applicant.Age"",""0""
    ""Applicant.IsInsured"",""True""";  // this is a string containing Environment.Newline
    var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    var newLines = new List<string>();
    string output;
    foreach (var line in lines)
    {     
        var key = line.Split(',')[0].Trim();
        var value = line.Split(',')[1].Trim();
        key = key.Substring(6);
        var newLine = string.Join(":", key, value);
        newLines.Add(newLine);
        Console.WriteLine(newLine);
    }
