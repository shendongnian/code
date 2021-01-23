            private static void Third()
            {
            try
            {
                throw new SystemException("ERROR HERE!");
            }
            catch (Exception ex)
            {
                // I WILL LOG THE EXCEPTION object "EX" here ! but ex.StackTrace is truncated!
                StackTrace st = new StackTrace(true);
                for (int i = 0; i < st.FrameCount; i++)
                {
                    // Note that high up the call stack, there is only
                    // one stack frame.
                    StackFrame sf = st.GetFrame(i);
                    Console.WriteLine();
                    Console.WriteLine("High up the call stack, Method: {0}",
                                      sf.GetMethod());
                    Console.WriteLine("High up the call stack, Line Number: {0}",
                                      sf.GetFileLineNumber());
                }
            }
        }
