    using System;
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
        private static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);
        [DllImport("winspool.drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndDocPrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool StartPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);
        public static bool PrintXpsToPdf(byte[] bytes, string outputFilePath, string documentTitle)
        {
            // Get Microsoft Print to PDF printer name
            var pdfPrinterName = GetMicrosoftPdfPrinterName();
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
            var success = SendBytesToPrinter(pdfPrinterName, ptrUnmanagedBytes, bytes.Length, di);
            // Free unmanaged memory
            Marshal.FreeCoTaskMem(ptrUnmanagedBytes);
            return success;
        }
        private static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount, DOCINFOA documentInfo)
        {
            var dwWritten = 0;
            var success = false;
            if (OpenPrinter(szPrinterName.Normalize(), out var hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, documentInfo))
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
            // If print did not succeed, GetLastError may give more information about the failure.
            if (success == false)
            {
                var dwError = Marshal.GetLastWin32Error();
                throw new Exception($"Printing to PDF failed. Error code: {dwError}.");
            }
            return success;
        }
        private static string GetMicrosoftPdfPrinterName()
        {
            PrintQueueCollection localQueues;
            using (var printServer = new PrintServer())
            {
                var flags = new[] { EnumeratedPrintQueueTypes.Local };
                localQueues = printServer.GetPrintQueues(flags);
            }
            var pdfPrintQueue = localQueues.SingleOrDefault(lq => lq.QueueDriver.Name == PdfPrinterDriveName);
            if (pdfPrintQueue == null)
            {
                throw new Exception($"Could not find printer with driver name: {PdfPrinterDriveName}");
            }
            return pdfPrintQueue.Name;
        }
    }
