    static void Main(string[] args)
    {
      var dict = new Dictionary<string, string>()
      {
        { "key1", "value1" }
      };
      string targetFile = Path.Combine(Environment.CurrentDirectory, "temp.txt");
      if (File.Exists( targetFile))
      {
        File.Delete(targetFile);
      }
      WriteDictionaryToFile(dict, targetFile);
      WriteDictionaryToFileEasy(dict, targetFile);
      WriteDictionaryToFileLinq(dict, targetFile);
      var lines = File.ReadAllLines(targetFile);
      Debug.Assert(lines.Length == 3, "Expected exactly 3 lines");
      Debug.Assert(string.Equals(lines[0], "key1|value1"), "First line should equal 'key1|value1'");
    }
