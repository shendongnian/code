      string value = ("{\"ID\":\"([A-Za-z0-9_., ]+)\",");
      MatchCollection match = Regex.Matches(textt, @value);
      string[] ID = new string[match.Count];
      for (int i = 0; i < match.Length; i++)
      {
      	ID[i] = match[i].Groups[1].Value; // (Index 1 is the first group)
      }
