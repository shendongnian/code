    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Threading;
    using System.IO;
    
    namespace Test
    {
        class Program
        {
            const string OutputFile = @"E:\Output.txt";
    
            object _lock = new object();
    
            static void Main(string[] args)
            {
                Program program = new Program();
    
                Thread thread = new Thread(program.ThreadMethod);
                thread.Start(@"E:\Test.txt");
    
                thread = new Thread(program.ThreadMethod);
                thread.Start(@"E:\DoesntExist.txt");
    
                Console.ReadKey();
            }
    
            void ThreadMethod(object filename)
            {
                String result = RunNormal(filename as string);
                lock (_lock)
                {
                    FileInfo fi = new FileInfo(OutputFile);
                    if (!fi.Exists)
                    {
                        try
                        {
                            fi.Create().Close();
                        }
                        catch (System.Security.SecurityException secEx)
                        {
                            Console.WriteLine("An exception has occured: {0}", secEx.Message);
                            return;
                        }
                    }
    
                    StreamWriter sw = fi.AppendText();
                    sw.WriteLine(result);
                    sw.Close();
                }
            }
    
            string RunNormal(string fullfilename)
            {
                try
                {
                    Process.Start(fullfilename);
                    return fullfilename + "|Success";
                }
                catch (Exception e)
                {
                    return fullfilename + "|" + e.ToString();
                }
            }
        }
    }
