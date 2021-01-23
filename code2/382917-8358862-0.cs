    using System;
    using System.IO;
    using System.Diagnostics;
    
    
    public class Test
    {
        public static void Main()
        {
            TextWriterTraceListener myWriter = new
            TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(myWriter);
            Debug.WriteLine("Test output 1 ");
            Stream myFile = File.Create("output.txt");
            TextWriterTraceListener myTextListener = new
            TextWriterTraceListener(myFile);
            Debug.Listeners.Add(myTextListener);
            Debug.WriteLine("Test output 2 ");
    
    
            if (!EventLog.SourceExists("Demo"))
            {
                EventLog.CreateEventSource("Demo", "Demo");
            }
    
    
            Debug.Listeners.Add(new EventLogTraceListener("Demo"));
            Debug.WriteLine("Test output 3 ");
            myWriter.Flush();
            myWriter.Close();
            myFile.Flush();
            myFile.Close();
        }
    }
