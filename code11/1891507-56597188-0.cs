    void Generate(object ref result, object ref resultGiven, int step)
    {
      // do stuf
    
      // break for debug
      if (step >= 6)
      {
        return; 
      }
      // or only break when debugger is attached
      if (System.Diagnostics.Debugger.IsAttached && step >= 6)
      {
        return; 
      }
      // recursive
      Generate(ref result, ref resultGiven, step++);
    }
