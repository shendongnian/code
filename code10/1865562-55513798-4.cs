      StringBuilder sb = new StringBuilder();
      foreach (Match match in Regex.Matches(source, @"(?<value>[^0-9]+)(?<times>[0-9]+)")) {
        string value = match.Groups["value"].Value.ToUpper();
        int times = int.Parse(match.Groups["times"].Value);
        for (int i = 0; i < times; ++i)
          sb.Append(value);
      }
      string result = sb.ToString();
