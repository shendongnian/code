    using System.Diagnostics;
    
    namespace Managed
    {
        class Program
        {
            static void Main(string[] args)
            {
                AssertWithCallSite(false, "Failed!");
            }
    
            [Conditional("DEBUG")]
            static void AssertWithCallSite(bool condition, string message)
            {
                if (!condition)
                {
                    var callSite = (new StackTrace(1, true)).GetFrame(0);
    
                    string fileName = callSite.GetFileName();
                    int lineNumber = callSite.GetFileLineNumber();
    
                    string assertMessage = string.Format(
                        "Assert at {0}:{1}:\n{2}",
                        fileName,
                        lineNumber,
                        message
                    );
    
                    Debug.Assert(false, assertMessage);
                }
            }
        }
    }
