    using System.Reflection;
       
    ParameterInfo[] info = MethodInfo.GetCurrentMethod().GetParameters();
    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(false);
    System.Diagnostics.StackFrame[] frames = trace.GetFrames();
