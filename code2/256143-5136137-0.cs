       System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace();
            System.Diagnostics.StackFrame frame = trace.GetFrame(0);
            MethodBase method = frame.GetMethod();
            MethodBody methodBody = method.GetMethodBody();
            if (methodBody != null)
            {
                foreach (var local in methodBody.LocalVariables)
                {
                    Console.WriteLine(local);
                }
            }
            Console.ReadKey();
