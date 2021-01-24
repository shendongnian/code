                using (var kernelSession = new TraceEventSession(KernelTraceEventParser.KernelSessionName))
                {
                    Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) { kernelSession.Dispose(); };
    
                    kernelSession.EnableKernelProvider
                        ( KernelTraceEventParser.Keywords.DiskFileIO |
                        KernelTraceEventParser.Keywords.FileIO |
                        KernelTraceEventParser.Keywords.FileIOInit
                        );
    
                   
                    var kernel = kernelSession.Source.Kernel;
                    kernel.FileIORead += HandleFileIoRead;
                    kernel.DiskIORead += HanleDiskIORead;
    
    
    
                    kernelSession.Source.Process();
                }
    
    
 <!>
            
            private static void HandleFileIoRead(FileIOReadWriteTraceData data)
            {
               
              if(data.ProcessName=="notepad")
                    Console.WriteLine("Hellonotepad" +data);
    
            }
    
