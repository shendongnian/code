    public static Dictionary<string, string> Load(string filename)
    {
      var config = new Dictionary<string, string>();
      foreach(string kvp in File.ReadLines(filename))
      {
        var parts = kvp.split(" ");
        config.Add(parts[0], parts[1].Replace("\"", ""););
      }
      return config;
    }
