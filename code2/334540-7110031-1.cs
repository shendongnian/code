    try
    {
        int a = 0;
        int i = 1 / a;
    }
    catch (Exception exception)
    {
        StackTrace s = new StackTrace(exception);
        StackFrame stackFrame = s.GetFrame(s.FrameCount - 1);
        if (stackFrame != null)
        {
            StringBuilder stackBuilder = new StringBuilder();
            MethodBase method = stackFrame.GetMethod();
            stackBuilder.AppendFormat("Method Name = {0}{1}Parameters:{1}", method.Name, Environment.NewLine);
            
            foreach (ParameterInfo parameter in method.GetParameters())
            {
                stackBuilder.AppendFormat("{0} {1}", parameter.ParameterType.FullName, parameter.Name);
                stackBuilder.AppendLine();
            }
            // or use this to get the value
            //stackBuilder.AppendLine("param1  = " + param1);
            //stackBuilder.AppendLine("param2  = " + param2);
        }
    }
