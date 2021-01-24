    string result = string.Empty;
    var lines = File.ReadAllLines("myLogFile.txt");
    foreach (var line in lines)
    {
        if(line.Contains("Error"))
        {
            errorList.Add(line);
        }
    }
