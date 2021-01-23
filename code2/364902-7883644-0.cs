    static void Main(string[] args) {
      var fname = args[0];
      var words = File.ReadAllLines(fname);
    
      Console.WriteLine("var stopWords = new string[] {");
      for(int i = 0; i < words.Length; ++i) {
        string word = words[i];
        Console.Write("@\"{0}\"", word.Replace("\"", "\\\""));
        if(i < words.Length - 1) {
          Console.Write(",");
        }
        Console.WriteLine();
      }
      Console.WriteLine("};");
    }
