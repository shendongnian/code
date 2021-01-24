    RegexOptions options = RegexOptions.None;
    Regex regex = new Regex("[ ]{2,}", options);     
    
    
    foreach (string line in lines)
    {
        line = regex.Replace(line, ",");
        Console.WriteLine(line);
    }
