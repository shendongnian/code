          [MethodImpl(MethodImplOptions.NoInlining)]  
          private void HandleSomeEvent(object parameter)  
          {  
                StackTrace stackTrace = new StackTrace();
                StackFrame stackFrame = stackTrace.GetFrame(1);
                MethodBase methodBase = stackFrame.GetMethod();
                if(methodBase.DeclaringType == typeof(ClassA)) // Okay.
                else if (methodBase.DeclaringType == typeof(ClassB)) // Okay.
                else throw new ApplicationException("Not Okay");
          }
 
