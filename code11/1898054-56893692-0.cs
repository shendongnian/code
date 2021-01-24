        Regex tokenizerRegex = new Regex(@"\{(.+?)\}");
        var s = "some random text{variable}";
        string[] splitted = s.Split(' ');
        var filteredSplit = splitted.SelectMany(word =>
        {
            if (tokenizerRegex.IsMatch(word)) //when a tokenized value were recognized
            {
                List<string> tokenizedSplit = new List<string>(); //collecting all parts
                int nextIndex = 0;
                foreach (Match match in tokenizerRegex.Matches(word)) //loop throug all matches
                {
                    if (nextIndex < match.Index - 1) //if there is a gap between two tokens or at the beginning, add the word
                        tokenizedSplit.Add(word.Substring(nextIndex, match.Index-nextIndex));
                    tokenizedSplit.Add(match.Value);
                    nextIndex = match.Index + match.Length; //Save the endposition of the token
                }
                return tokenizedSplit.ToArray();
            }
            return new string[] { word }; //no token found, just add the word.
        }).ToArray();
