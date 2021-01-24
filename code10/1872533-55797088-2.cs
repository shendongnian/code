    RegexOptions options = RegexOptions.None;
    Regex regex = new Regex("[ ]{2,}", options);     
    
    string csvline;
    foreach (string line in lines)
    {
        csvline = regex.Replace(line, ",");
        Console.WriteLine(csvline);
    }
