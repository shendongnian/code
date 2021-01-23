    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    namespace testHarness
    {
        class Program
        {
            static void Main( string[] args )
            {
                IEnumerable<bool> Redirections = new bool[]{ false , true } ;
                foreach ( bool redirecting in Redirections )
                {
                    int cc ;
                    using ( Process test = new Process() )
                    {
                        test.StartInfo.FileName               = "cmd.exe"       ;
                        test.StartInfo.Arguments              = @"/c setcc 17 " ;
                        test.StartInfo.RedirectStandardError  = redirecting     ;
                        test.StartInfo.RedirectStandardOutput = redirecting     ;
                        test.StartInfo.UseShellExecute        = false           ;
                        test.StartInfo.CreateNoWindow         = true            ;
                        test.Start()  ;
                        test.WaitForExit() ;
                        cc = test.ExitCode ;
                    }
                    Console.WriteLine( "Redirecting:{0}, cc is {1}" , redirecting , cc ) ;
                }
                return ;
            }
        }
    }
