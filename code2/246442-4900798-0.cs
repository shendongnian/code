        [Conditional("DEBUG")]
        public static void DebugPrintTrace(string message)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackframe = stackTrace.GetFrame(1);
            Console.WriteLine("Trace "
                + sf.GetMethod().Name + " "
                + sf.GetFileName() + ":"
                + sf.GetFileLineNumber() + Enviroment.NewLine);
           Console.WriteLine(message + Enviroment.NewLine);
        } 
