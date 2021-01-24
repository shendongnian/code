      string[] data = new string[] {
        "v2.9.0", "v2.10.0", "v2.11.0", "v2.12.0", 
        "v2.13.0", "v2.14.0", "v2.15.0", "v2.16.0", 
        "v2.1.0", "v2.2.0"
      };
      string[] sorted = data
        .OrderBy(item => Version.Parse(Regex.Match(item, @"[0-9]+(?:\.[0-9]+)+").Value))
        .ToArray();
      Console.Write(string.Join(Environment.NewLine, sorted));
