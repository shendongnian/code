        Regex tokenizerRegex = new Regex(@"\{(.+?)\}");
        var s = "some random text{variable}";
        string[] splitted = s.Split(' ');
        List<string> result = new List<string>();
        foreach (string word in splitted)
        {
            if (tokenizerRegex.IsMatch(word)) //when a tokenized value were recognized
            {
                int nextIndex = 0;
                foreach (Match match in tokenizerRegex.Matches(word)) //loop throug all matches
                {
                    if (nextIndex < match.Index - 1) //if there is a gap between two tokens or at the beginning, add the word
                        result.Add(word.Substring(nextIndex, match.Index - nextIndex));
                    result.Add(match.Value);
                    nextIndex = match.Index + match.Length; //Save the endposition of the token
                }
            }
            else
                result.Add(word);//no token found, just add the word.
        }
        Console.WriteLine("[\"{0}\"]",string.Join("\", \"", result));
