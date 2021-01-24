    using System.Diagnostics;
    ...
    void Generate(ref result, ref resultGiven) {
      // --- Comment this out after debugging
      string current = new StackTrace(new StackFrame(false)).ToString().Trim();
      StackTrace st = new StackTrace();
      int count = st
        .ToString()
        .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
        .TakeWhile(record => record.Trim() == current)
        .Count();
      if (count <= 6)
        return;  
      // --- Comment this out after debugging
      ...
    }
