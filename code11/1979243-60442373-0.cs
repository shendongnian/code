    using Microsoft.Windows.EventTracing;
    using Microsoft.Windows.EventTracing.Processes;
    using System;
    using System.Globalization;
    
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Usage: ListImages.exe <trace.etl>");
                return;
            }
    
            string tracePath = args[0];
    
            using (ITraceProcessor trace = TraceProcessor.Create(tracePath))
            {
                IPendingResult<IProcessDataSource> pendingProcessData = trace.UseProcesses();
    
                trace.Process();
    
                IProcessDataSource processData = pendingProcessData.Result;
    
                foreach (IProcess process in processData.Processes)
                {
                    foreach (IImage image in process.Images)
                    {
                        DataSize ImageSize = image.Size;
                        long TimeDataStamp = image.Timestamp;
                        string OrigFileName = image.OriginalFileName;
                        string FileDescription = image.FileDescription;
                        string FileVersion = image.FileVersion;
                        Version BinFileVersion = image.FileVersionNumber;
                        CultureInfo VerLanguage = image.Locale;
                        string ProductName = image.ProductName;
                        string CompanyName = image.CompanyName;
                        string ProductVersion = image.ProductVersion;
                        string FileId = image.CompatibilityFileId;
                        string ProgramId = image.CompatibilityProgramId;
                    }
                }
            }
        }
    }
