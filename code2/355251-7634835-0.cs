    string input = "Last Run: 2011-10-03 13:58:54 (7m 30s  ago) [status] ";
    string pattern = @"\d+m \d+s";
    string replacement = "yay";
    Regex rgx = new Regex(pattern);
    string result = rgx.Replace(input, replacement);
    
    Console.WriteLine("Original String: {0}", input);
    Console.WriteLine("Replacement String: {0}", result);  
