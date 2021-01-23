    using System.Text.RegularExpressions;
    StreamReader sr = new StreamReader(yourtextfilepath);
    string input;
    string pattern = @"\b(\w+)\s\1\b";//Whatever Regular Expression Pattern goes here
    while (sr.Peek() >= 0)
    {
       input = sr.ReadLine();
       Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
       MatchCollection matches = rgx.Matches(input);
       if (matches.Count > 0)
       {          
          foreach (Match match in matches)
             //Print it or whatever 
             Console.WriteLine(match.Value);
       }
    }
    sr.Close();
   
