     var pattern = @"\b(some[wW]ord|[\d]|\s)*\b";
     var rgx = new Regex(pattern);
     var sentence = "43434 of someword 12 anything someword 2323 new someword";
     var result = string.Empty;
     foreach (Match match in rgx.Matches(sentence))
         result += match.Value;
     var patternOnCorrectSentence = @"\b(\d+)\s*some[wW]ord*\b";
     var rgxOnCorrectSentence = new Regex(patternOnCorrectSentence);
     var resultOnCorrectSentence = new List<string>();
     foreach (Match match in rgxOnCorrectSentence.Matches(result))
         resultOnCorrectSentence.Add(match.Value);
     resultOnCorrectSentence.ForEach(Console.WriteLine);
     Console.ReadKey();
