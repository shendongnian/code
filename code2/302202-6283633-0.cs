    StreamReader sr = new StreamReader("yourfile.txt");
    Regex reg = new Regex(@"\w\:(.(?!\:))+");
    List<string> parsedStrings = new List<string>();
    while (!sr.EndOfStream) 
    {
        parsedStrings.Add(reg.Match(sr.ReadLine()).Value);
    }
