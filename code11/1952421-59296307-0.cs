    var stack = new StackFrame(ex, true);
    StackFrame frame = null;
    for (int i = 0; i < stack.FrameCount; i++)
    {
        frame = stack.GetFrame(i);
        if (frame.GetFileLineNumber() > 0) break;
    }
    Console.WriteLine("Exception message: {0}", ex.Message);
    Console.WriteLine("Exception in file: {0}", frame.GetFileName());
    Console.WriteLine("Exception in method: {0}", frame.GetMethod());
    Console.WriteLine("Exception at line number: {0}", frame.GetFileLineNumber());
