    public class DumpStackTraceListener : TraceListener
    {
      public override void Write( string message )
      {
         Console.Write( message );
      }
      public override void WriteLine(string message)
      {
         Console.WriteLine( message );
      }
      public override void Fail(string message)
      {
         Fail( message, String.Empty );
      }
      public override void Fail(string message1, string message2)
      {
         if (null == message2)
            message2 = String.Empty;
         Console.WriteLine( "{0}: {1}", message1, message2 );
         Console.WriteLine( "Stack Trace:" );
         StackTrace trace = new StackTrace( true );
         foreach (StackFrame frame in trace.GetFrames())
         {
            MethodBase frameClass = frame.GetMethod();
            Console.WriteLine( "  {2}.{3} {0}:{1}", 
                               frame.GetFileName(),
                               frame.GetFileLineNumber(),
                               frameClass.DeclaringType,
                               frameClass.Name );
         }
    #if DEBUG
         Console.WriteLine( "Exiting because Fail" );
         Environment.Exit( 1 );
    #endif
      }
    }
