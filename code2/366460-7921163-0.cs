    static void Main(string[] args) {
      // first check if there are arguments
      if (args.length > 0)
      {
         // check if the filename has the right extension
         if (args[0].EndsWith(".ext"))
         {
            // check for existence
            if (System.IO.File.Exists(args[0]))
            {
               // it exists.. so store the filename in the previously defined variable
               filename = args[0];
            }
         }
      }
    }
