    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Reflection;
    using System.Text.RegularExpressions;
    namespace YourApp
    {
    class DebugE
    {
        public static void d(Exception e)
        {
            try
            {
                MethodBase site = e.TargetSite;//Get the methodname from the exception.
                string methodName = site == null ? "" : site.Name;//avoid null ref if it's null.
                methodName = ExtractBracketed(methodName);
                StackTrace stkTrace = new System.Diagnostics.StackTrace(e, true);
                for (int i = 0; i < 3; i++)
                {
                    //In most cases GetFrame(0) will contain valid information, but not always. That's why a small loop is needed. 
                    var frame = stkTrace.GetFrame(i);
                    int lineNum = frame.GetFileLineNumber();//get the line and column numbers
                    int colNum = frame.GetFileColumnNumber();
                    string className = ExtractBracketed(frame.GetMethod().ReflectedType.FullName);
                    Trace.WriteLine(ThreadAndDateInfo + "Exception: " + className + "." + methodName + ", Ln " + lineNum + " Col " + colNum + ": " + e.Message);
                    if (lineNum + colNum > 0)
                        break; //exit the for loop if you have valid info. If not, try going up one frame...
                }
            }
            catch (Exception ee)
            {
                //Avoid any situation that the Trace is what crashes you application. While trace can log to a file. Console normally not output to the same place.
                Console.WriteLine("Tracing exception in d(Exception e)" + ee.Message);
            }
        }
        public static void d(string str)
        {
            try
            {
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                string name = ExtractBracketed(method.Name);//extract the content that is inside <brackets> the rest is irrelevant 
                Trace.WriteLine(ThreadAndDateInfo + method.DeclaringType + "." + name + ": " + str);
            }
            catch (Exception e)
            {
                Console.WriteLine("Tracing exception in d(string str)" + e.Message);
            }
        }
        private static string ExtractBracketed(string str)
        {
            string s;
            if (str.IndexOf('<') > -1) //using the Regex when the string does not contain <brackets> returns an empty string.
                s = Regex.Match(str, @"\<([^>]*)\>").Groups[1].Value;
            else
                s = str; 
            if (s == "")
                return  "'Emtpy'"; //for log visibility we want to know if something it's empty.
            else
                return s;
        }
        public static string ThreadAndDateInfo
        {
            //returns thread number and precise date and time.
            get { return "[" + Thread.CurrentThread.ManagedThreadId + " - " + DateTime.Now.ToString("dd/MM HH:mm:ss.ffffff") + "] "; }
        }
    }
    }
