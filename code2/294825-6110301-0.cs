     StackTrace trace=new StackTrace();
                StackFrame[] stackFrames = trace.GetFrames();
                foreach (var stackFrame in stackFrames)
                {
                    string methodName= stackFrame.GetMethod().Name;
                    string declearingClass=stackFrame.GetMethod().DeclaringType.Name;
                    
                }
