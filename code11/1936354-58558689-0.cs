    string PrinterName = @"\\Server\nameOfThePrinter";
                ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                {
                    Verb = "PrintTo",
                    CreateNoWindow = true,
                    FileName = pdfFileName,
                    Arguments = "\"" + PrinterName + "\"",
                    WindowStyle = ProcessWindowStyle.Hidden
                };
    
                Process printProcess = new Process();
                printProcess.StartInfo = printProcessInfo;
                printProcess.Start();
                printProcess.WaitForInputIdle();
       
                printProcess.WaitForExit(10000);
    
                if (printProcess.HasExited)
                {
    
                }else
                {
                    printProcess.Kill();
                }
    
                return true;
