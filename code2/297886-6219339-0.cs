    static void Main(string[] args)
    {
      string SolutionPath;
      if (args != null && args.Length > 0)
        SolutionPath = args[0];
      else
        SolutionPath = @"c:\Projects\TestDXCoreConsoleApp\TestDXCoreConsoleApp.sln";
    
      try
      {
        ParserHelper.RegisterParserServices();
    
        Console.Write("Parsing solution... ");
    
        SolutionParser solutionParser = new SolutionParser(SolutionPath);
        SolutionElement solution = solutionParser.GetParsedSolution();
        if (solution == null)
          return;
    
        Console.WriteLine("Done.");
    
        foreach (ProjectElement project in solution.AllProjects)
          foreach (SourceFile file in project.AllFiles)
            foreach (TypeDeclaration type in file.AllTypes)
            {
              Console.Write(type.FullName);
              Console.WriteLine(", members: " + ((ITypeElement)type).Members.Count);
            }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        ParserHelper.UnRegisterParserServices();
      }
    
      Console.ReadLine();
    }
