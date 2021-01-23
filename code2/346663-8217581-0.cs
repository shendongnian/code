    internal string GetCallingMethodName()
    {
      string result = "unknown";
      StackTrace trace = new StackTrace(false);
      for (int i = 0; i < trace.FrameCount; i++)
      {
        StackFrame frame = trace.GetFrame(i);
        MethodBase method = frame.GetMethod();
        Type dt = method.DeclaringType;
        if (!typeof(ILogger).IsAssignableFrom(dt) && method.DeclaringType.Namespace != "DiagnosticsLibrary")
        {
          result = string.Concat(method.DeclaringType.FullName, ".", method.Name);
          break;
        }
      }
      return result;
    }
