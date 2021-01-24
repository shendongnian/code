    string sentence = "I wandered lonely as a cow";
    var result = string.Join("; ", Regex
      .Matches(sentence, "[A-Za-z]+")  // Word is a sequence of A..Z a..z letters
      .OfType<Match>()
      .Select((match, index) => new {
        word = match.Value.ToLower(),  // So we have word, e.g. "lonely" 
        index                          // and its index, e.g. "2"  
      })
      .SelectMany(item => item.word.Select(c => new {
        character = c,               // for each character 
        wordNumber = item.index + 1  // we have a index of the word(s) where it appears
      }))
      .GroupBy(item => item.character, item => item.wordNumber) // grouping by character
      .Select(chunk => $"{chunk.Key} - {string.Join(",", chunk.Distinct().OrderBy(n => n))}"));
      Console.Write(result);
