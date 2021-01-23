    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    
    namespace TestApp
    {
        internal static class Program
        {
            [MTAThread]
            public static void Main(string[] args)
            {
                const string fileName = @"..\..\..\ChildConsoleApp\bin\Debug\ChildConsoleApp.exe";
    
                // Fires up a new process to run inside this one
                var process = Process.Start(new ProcessStartInfo
                {
                    UseShellExecute = false,
    
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
    
                    FileName = fileName
                });
    
                // Depending on your application you may either prioritize the IO or the exact opposite
                const ThreadPriority ioPriority = ThreadPriority.Highest;
                var outputThread = new Thread(outputReader) { Name = "ChildIO Output", Priority = ioPriority};
                var errorThread = new Thread(errorReader) { Name = "ChildIO Error", Priority = ioPriority };
                var inputThread = new Thread(inputReader) { Name = "ChildIO Input", Priority = ioPriority };
    
                // Set as background threads (will automatically stop when application ends)
                outputThread.IsBackground = errorThread.IsBackground
                    = inputThread.IsBackground = true;
    
                // Start the IO threads
                outputThread.Start(process);
                errorThread.Start(process);
                inputThread.Start(process);
    
                // Demonstrate that the host app can be written to by the application
                process.StandardInput.WriteLine("Message from host");
                
                // Signal to end the application
                ManualResetEvent stopApp = new ManualResetEvent(false);
    
                // Enables the exited event and set the stopApp signal on exited
                process.EnableRaisingEvents = true;
                process.Exited += (e, sender) => { stopApp.Set(); };
    
                // Wait for the child app to stop
                stopApp.WaitOne();
    
                // Write some nice output for now?
                Console.WriteLine();
                Console.Write("Process ended... shutting down host");
                Thread.Sleep(1000);
            }
    
            /// <summary>
            /// Continuously copies data from one stream to the other.
            /// </summary>
            /// <param name="instream">The input stream.</param>
            /// <param name="outstream">The output stream.</param>
            private static void passThrough(Stream instream, Stream outstream)
            {
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int len;
                    while ((len = instream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        outstream.Write(buffer, 0, len);
                        outstream.Flush();
                    }
                }
            }
    
            private static void outputReader(object p)
            {
                var process = (Process)p;
                // Pass the standard output of the child to our standard output
                passThrough(process.StandardOutput.BaseStream, Console.OpenStandardOutput());
            }
    
            private static void errorReader(object p)
            {
                var process = (Process)p;
                // Pass the standard error of the child to our standard error
                passThrough(process.StandardError.BaseStream, Console.OpenStandardError());
            }
    
            private static void inputReader(object p)
            {
                var process = (Process)p;
                // Pass our standard input into the standard input of the child
                passThrough(Console.OpenStandardInput(), process.StandardInput.BaseStream);
            }
        }
    }
