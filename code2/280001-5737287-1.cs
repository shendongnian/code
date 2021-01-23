    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Management;
    namespace WaitOnParentProcessSample
    {
        class Program
        {
            static int Main( string[] argv )
            {
                using ( Process parentProcess = GetParentProcess() )
                {
                    Console.WriteLine( "Waiting for parent process (pid:{0}) to exit..." , parentProcess.Id );
                    parentProcess.WaitForExit();
                    Console.WriteLine( "Parent Process Has exited. Condition code cannot be determined" );
                }
                return 0;
            }
            private static Process GetParentProcess()
            {
                Process parentProcess  = null;
                using ( Process currentProcess = Process.GetCurrentProcess() )
                {
                    string      filter = string.Format( "ProcessId={0}" , currentProcess.Id );
                    SelectQuery query  = new SelectQuery( "Win32_Process" , filter );
                    using ( ManagementObjectSearcher   searcher = new ManagementObjectSearcher( query ) )
                    using ( ManagementObjectCollection results  = searcher.Get() )
                    {
                        if ( results.Count>0 )
                        {
                            if ( results.Count>1 )
                                throw new InvalidOperationException();
                            IEnumerator      resultEnumerator = results.GetEnumerator();
                            bool             fMoved           = resultEnumerator.MoveNext();
                            using ( ManagementObject wmiProcess = (ManagementObject)resultEnumerator.Current )
                            {
                                PropertyData parentProcessId = wmiProcess.Properties["ParentProcessId"];
                                uint         pid = (uint)parentProcessId.Value;
                                parentProcess=Process.GetProcessById( (int)pid );
                            }
                        }
                    }
                }
                return parentProcess;
            }
        }
    }
