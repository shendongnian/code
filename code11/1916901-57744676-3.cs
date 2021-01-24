    List<TranslationResult> a = JsonConvert.DeserializeObject<List<TranslationResult>>(jsonResponse);
    
    IEnumerable<(string DisplayTarget, string PosTag)> tuples = 
      a.Where(t0 => t0?.Translations ?? false)
        .SelectMany(
          t0 => t0.Translations.Select(
            t1 => (DisplayTarget: t1?.DisplayTarget ?? string.Empty, PosTag: t1?.PosTag ?? string.Empty)));
    
    // Iterate over the result of named tuples
    foreach ((string DisplayTarget, string PosTag) tuple : tuples)
    {
      // Values are string.Empty when they returned null from deserialization
      var displayTarget = tuple.DisplayTarget;
      var posTag = tuple.PosTag;
    }
