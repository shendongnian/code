    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Reflection;
    using System.Text.RegularExpressions;
    namespace WhatsAppDelayer
    {
    class DebugE
    {
        public static void d(Exception e)
        {
            MethodBase site = e.TargetSite;//Get the methodname from the exception.
            string methodNameLnCol = site == null ? "" : site.Name;//avoid null ref if it's null.
            methodNameLnCol = ExtractBracketed(methodNameLnCol);
            StackTrace stkTrace = new System.Diagnostics.StackTrace(e, true);
            //get the line and column numbers
            methodNameLnCol += ", Ln " + +stkTrace.GetFrame(0).GetFileLineNumber() + " Col " + stkTrace.GetFrame(0).GetFileColumnNumber() + ": ";
            string className = (stkTrace.GetFrame(0).GetMethod().ReflectedType.Name);
            Trace.WriteLine(ThreadAndDateInfo + className + "." + methodNameLnCol + e.Message);
        }
        public static void d(string str)
        {
            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();
            string name = ExtractBracketed(method.Name);//extract the content that is inside <brackets> the rest is irrelevant 
            Trace.WriteLine(ThreadAndDateInfo + method.DeclaringType + "." + name + ": " + str);
        }
        private static string ExtractBracketed(string str)
        {
            return Regex.Match(str, @"\<([^>]*)\>").Groups[1].Value;
        }
        public static string ThreadAndDateInfo
        { 
            //returns thread number and precise date and time.
            get { return "[" + Thread.CurrentThread.ManagedThreadId + " - " + DateTime.Now.ToString("HH:mm:ss.ffffff") + "] "; }
        }
    }
    }
