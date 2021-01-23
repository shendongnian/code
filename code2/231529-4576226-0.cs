            Exception ex = Server.GetLastError().GetBaseException();       
            StackTrace trace = new StackTrace(ex, true);
            if (trace.FrameCount == 0)
                return;
            StackFrame stackFrame = trace.GetFrame(0);
            string className, fileName, functionName, message;
            int line = 0;
            // if for some reason, filename is being retrieved as null
            if (stackFrame.GetFileName() == null)
            {
                className = ex.TargetSite.ReflectedType.Name;
                fileName = ex.TargetSite.ReflectedType.Name;
                functionName = ex.TargetSite.Name;
                message = ex.Message;
            }
            else
            {
                // Collect data where exception occured
                string[] splitFile = stackFrame.GetFileName().Split('\\');
                className = splitFile[splitFile.Length - 1];
                fileName = stackFrame.GetFileName();
                functionName = stackFrame.GetMethod().Name;
                message = ex.Message;
                line = stackFrame.GetFileLineNumber();
            }
