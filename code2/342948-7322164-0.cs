    using System;
    using System.Dynamic;
    using System.Reflection;
    
    public class SomeClass : DynamicObject
    {
        // Core functionality
        public static void WriteToLog(string message, EventLogEntryType type)
        {
            ...
        }
        // Overloaded methods for common uses
        public static void WriteToLog(SomeObject obj)
        {
            WriteToLog(obj.ToString(), EventLogEntryType.Information);
        }
        public static void WriteToLog(SomeException ex)
        {
            WriteToLog(ex.Message, EventLogEntryType.Error);
        }
        // Redirect all method calls that start with 'Try' to corresponding normal
        // methods, but encapsulate the method call in a try ... catch to ignore
        // log-related errors
        private static dynamic instance = new Logger();
        public static dynamic Instance { get { return instance; } }
        public override bool TryInvokeMember(InvokeMemberBinder binder, 
                                             object[] args, 
                                             out object result)
        {
            if (binder.Name.StartsWith("Try"))
            {
                try
                {
                    result = this.GetType().InvokeMember(binder.Name.Substring(3),
                                                         BindingFlags.InvokeMethod, 
                                                         null, 
                                                         this,
                                                         args);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    result = null;
                }
                return true;
            }
            else
            {
                return base.TryInvokeMember(binder, args, out result);
            }
        }
