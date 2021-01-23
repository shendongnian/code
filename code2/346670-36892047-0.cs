    using System.Diagnostics;
    ...
    static private string GetCallsite()
    {
      StackFrame sf = new StackTrace(1/*Skip one frame - dive to the callers context*/, true/*Yes I want the file info !*/).GetFrame(0);
      return "{" + sf.GetFileName() + " | " + sf.GetMethod().Name + "-" + sf.GetFileLineNumber() + "} ";
    }
