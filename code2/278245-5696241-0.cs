      StackTrace st = new StackTrace(new StackFrame(1));
      Console.WriteLine(" Stack trace for next level frame: {0}",
         st.ToString());
      Console.WriteLine(" Stack frame for next level: ");
      Console.WriteLine("   {0}", st.GetFrame(0).ToString());
      Console.WriteLine(" Line Number: {0}",
         st.GetFrame(0).GetFileLineNumber().ToString());
