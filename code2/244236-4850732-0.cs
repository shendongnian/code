    string inputString = "test (10)";
    
    Regex regex = new Regex(@"(.+)\((?<Digit>\d+)\)");
    Match match = regex.Match(inputString);
    
    int i = Convert.ToInt32(match.Groups["Digit"].Value);
    i++;
    
    string replacePattern = "$1(" + i + ")";
    string newString = regex.Replace(inputString, replacePattern);
    
    Console.WriteLine(newString);
