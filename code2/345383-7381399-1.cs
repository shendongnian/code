    using System.Diagnostics;
    ...
    [Conditional("DEBUG")]
    internal static void Assert(bool condition)
    {
        if (!condition)
        {
            StackFrame frame = new StackFrame(1, true);
            var message = string.Format("Line: {0}\r\nColumn: {1}\r\nWhere:{2}",
                                        frame.GetFileLineNumber(),
                                        frame.GetFileColumnNumber(),
                                        frame.GetMethod.Name);
            Log("ASSERTION", message);
        }
    }
