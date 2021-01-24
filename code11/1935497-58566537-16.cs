    using System;
    using System.Linq;
    using System.Printing;
    using System.Runtime.InteropServices;
    public static class PdfFilePrinter
    {
        private const string PdfPrinterDriveName = "Microsoft Print To PDF";
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)] 
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)] 
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)] 
            public string pDataType;
        }
        [DllImport("winspool.drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);
        [DllImport("winspool.drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool ClosePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int StartDocPrinter(IntPtr hPrinter, int level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);
        [DllImport("winspool.drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndDocPrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool StartPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);
        public static void PrintXpsToPdf(byte[] bytes, string outputFilePath, string documentTitle)
        {
            // Get Microsoft Print to PDF print queue
            var pdfPrintQueue = GetMicrosoftPdfPrintQueue();
            // Copy byte array to unmanaged pointer
            var ptrUnmanagedBytes = Marshal.AllocCoTaskMem(bytes.Length);
            Marshal.Copy(bytes, 0, ptrUnmanagedBytes, bytes.Length);
            // Prepare document info
            var di = new DOCINFOA
            {
                pDocName = documentTitle, 
                pOutputFile = outputFilePath, 
                pDataType = "RAW"
            };
            // Print to PDF
            var errorCode = SendBytesToPrinter(pdfPrintQueue.Name, ptrUnmanagedBytes, bytes.Length, di, out var jobId);
            // Free unmanaged memory
            Marshal.FreeCoTaskMem(ptrUnmanagedBytes);
            if (errorCode > 0)
            {
                pdfPrintQueue.Dispose();
                throw new Exception($"Printing to PDF failed. Error code: {errorCode}.");
            }
            // Check if job in error state (for example not enough disk space)
            var jobFailed = false;
            try
            {
                var pdfPrintJob = pdfPrintQueue.GetJob(jobId);
                if (pdfPrintJob.IsInError)
                {
                    jobFailed = true;
                    pdfPrintJob.Cancel();
                }
            }
            catch
            {
                // If job succeeds, GetJob will throw an exception. Ignore it. 
            }
            finally
            {
                pdfPrintQueue.Dispose();
            }
            if (jobFailed)
            {
                throw new Exception("PDF Print job failed.");
            }
        }
        private static int SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount, DOCINFOA documentInfo, out int jobId)
        {
            jobId = 0;
            var dwWritten = 0;
            var success = false;
            if (OpenPrinter(szPrinterName.Normalize(), out var hPrinter, IntPtr.Zero))
            {
                jobId = StartDocPrinter(hPrinter, 1, documentInfo);
                if (jobId > 0)
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        success = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // TODO: The other methods such as OpenPrinter also have return values. Check those?
            if (success == false)
            {
                return Marshal.GetLastWin32Error();
            }
            return 0;
        }
        private static PrintQueue GetMicrosoftPdfPrintQueue()
        {
            PrintQueue pdfPrintQueue = null;
            try
            {
                using (var printServer = new PrintServer())
                {
                    var flags = new[] { EnumeratedPrintQueueTypes.Local };
                    pdfPrintQueue = printServer.GetPrintQueues(flags).SingleOrDefault(lq => lq.QueueDriver.Name == PdfPrinterDriveName);
                }
                if (pdfPrintQueue == null)
                {
                    throw new Exception($"Could not find printer with driver name: {PdfPrinterDriveName}");
                }
                if (!pdfPrintQueue.IsXpsDevice)
                {
                    throw new Exception($"PrintQueue '{pdfPrintQueue.Name}' does not understand XPS page description language.");
                }
                return pdfPrintQueue;
            }
            catch
            {
                pdfPrintQueue?.Dispose();
                throw;
            }
        }
    }
