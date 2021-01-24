    using System.Diagnostics;
    ...
    void Generate(ref result, ref resultGiven) {
      // --- Comment this out after debugging
      string currentFrame = new StackTrace(new StackFrame(false)).ToString().Trim();
      StackTrace trace = new StackTrace();
      int count = trace
        .ToString()
        .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
        .TakeWhile(frame => frame.Trim() == currentFrame)
        .Count();
      if (count <= 6)
        return;  
      // --- Comment this out after debugging
      ...
    }
