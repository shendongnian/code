    private static string MyModify(string text, string wordsToExclude) {
      HashSet<string> exclude = new HashSet<string>(
        wordsToExclude.Split(' '), StringComparer.OrdinalIgnoreCase);
      bool inSelection = false;
      string result = Regex.Replace(text, @"[\w']+", match => {
          var next = match.NextMatch();
          if (inSelection) {
            if (next.Success && exclude.Contains(next.Value)) {
              inSelection = false;
              return match.Value + "</b>";
            }
            else
              return match.Value;
          }
          else {
            if (exclude.Contains(match.Value))
              return match.Value;
            else if (next.Success && exclude.Contains(next.Value))
              return "<b>" + match.Value + "</b>";
            else {
              inSelection = true;
              return "<b>" + match.Value;
            }
          }
        });
      if (inSelection)
        result += "</b>";
      return result;
    }
