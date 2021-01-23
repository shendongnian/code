         private void PrintFormPdfData(byte[] formPdfData)
         {
            string tempFile;
            tempFile = Path.GetTempFileName();
            using (FileStream fs = new FileStream(tempFile, FileMode.Create))
            {
                fs.Write(formPdfData, 0, formPdfData.Length);
                fs.Flush();
            }
            string pdfArguments =string.Format("/t /o {0} \"Printer name\"", tempFile);
            
            string pdfPrinterLocation = @"C:\Program Files (x86)\Adobe\Reader 9.0\Reader\AcroRd32.exe";
             try
            {
            ProcessStarter processStarter = new ProcessStarter("AcroRd32", pdfPrinterLocation, pdfArguments);
            processStarter.Run();
            processStarter.WaitForExit();
            processStarter.Stop();
            }
             finally
             {
                 File.Delete(tempFile);
             }
           
    }
