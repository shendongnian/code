      const string sReportsProgram = "SomethingReports.exe";
      static void RunWithArgs(params object[] pArgs) {
         // .Join here is my own extension method which calls string.Join
         RunWithArgs(pArgs.Select(arg => arg.ToString()).Join(" "));
      }
      static void RunWithArgs(string pArgs) {
         Console.WriteLine("Running Report Program: {0} {1}", sReportsProgram, pArgs);
         var process = new Process();
         process.StartInfo.FileName = sReportsProgram;
         process.StartInfo.Arguments = pArgs;
         process.Start();
      }
