     public static void Assert(bool val, string message,  [CallerFilePath] string file = "",  [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
        {
            string msg = String.Format($"File: {file}, Method: {memberName}, Line Number: {lineNumber}\n\n{message}");
            Debug.Assert(val, msg);
            
        }
