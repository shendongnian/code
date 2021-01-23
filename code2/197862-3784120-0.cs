    public static IEnumerable<string> ReadAllLinesLazy(string path) { 
      using ( var stream = new StreamReader(path) ) {
        while (!stream.EndOfStream) {
          yield return stream.ReadLine();
        }
      }
    }
