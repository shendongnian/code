    // The words you want to search for
    var words = new string[] { "this", "is" };
    
    // Build a regular expresion query
    var wordRegexQuery = new System.Text.StringBuilder();
    wordRegexQuery.Append("\\b(");
    for (var wordIndex = 0; wordIndex < words.Length; wordIndex++)
    {
      wordRegexQuery.Append(words[wordIndex]);
      if (wordIndex < words.Length - 1)
      {
        wordRegexQuery.Append('|');
      }
    }
    wordRegexQuery.Append(")\\b");
    
    // Find matches and return them as a string[]
    var regex = new System.Text.RegularExpressions.Regex(wordRegexQuery.ToString(), RegexOptions.IgnoreCase);
    var someText = var someText = "This is some text which is quite a good test of which word is used most often. Thisis isthis athisisa.";
    var matches = (from Match m in regex.Matches(someText) select m.Value).ToArray();
    
    // Display results
    foreach (var word in words)
    {
    	var wordCount = (int)matches.Count(w => w.Equals(word, StringComparison.InvariantCultureIgnoreCase));
    	Console.WriteLine("{0}: {1} ({2:f2}%)", word, wordCount, wordCount * 100f / matches.Length);
    }
