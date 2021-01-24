    using System.Diagnostics;
    ...
    void Generate(ref result, ref resultGiven) {
      // --- Comment this out after debugging
      string currentFrame = new StackTrace(new StackFrame(false)).ToString().Trim();
      StackTrace trace = new StackTrace();
      int depth = trace
        .ToString()
        .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
        .TakeWhile(frame => frame.Trim() == currentFrame)
        .Count();
      // Prevent Generate to call itself more than 6 time 
      if (depth > 6) {
        // Maximum depth reached, return or launch debugger - Debugger.Launch()
        return;  
      }
      // --- Comment this out after debugging
      ...
    }
