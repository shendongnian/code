    class Program
    {
        public static void DoSomething()
        {
            string blah = null;
            Console.WriteLine(blah.Length);
        }
        static void Main(string[] args)
        {
            try
            {
                DoSomething();
            }
            catch (NullReferenceException e)
            {
                string methodName = e.TargetSite.Name;
                Console.WriteLine(methodName);
                System.Diagnostics.StackTrace trace =
                    new System.Diagnostics.StackTrace(e, true);
                int lineNumber = trace.GetFrame(0).GetFileLineNumber();
                Console.WriteLine(lineNumber);
                if(methodName == "DoSomething" && lineNumber == 13)
                {
                    ShowErrorToUser(); // Todo: Implement this
                }
                else
                {
                    throw; // Just re-throw the error if you don't know where it came from
                }
            }
        }
    }
