    var words = new List<string>();
    var stopWords = new HashSet<string>(TextOperationConstants.StopWords);
    foreach (var term in text.Split(TextOperationConstants.WordsSeparators))
    {
          if (String.IsNullOrWhiteSpace(term)) continue;
          if (stopWords.Contains(term)) continue;
          words .Add(term);
    }
