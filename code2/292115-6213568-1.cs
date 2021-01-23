    static void Main(string[] args)
    {
      if(args.Length == 1 && File.Exists(args[0]))
      {
        var assambly = CompileCode(File.ReadAllText(args[0]));
        ...
      }  
    }
