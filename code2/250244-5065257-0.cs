    using (TemporaryFile oTempInputFile = new TemporaryFile())
    {
        //write the content out to the temporary file
        using (StreamWriter oWriter = new StreamWriter(oTempInputFile.FilePath, false, System.Text.Encoding.UTF8))
        {
            oWriter.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            oWriter.WriteLine(oTextNode.OuterXml);
            oWriter.Close();
        }
        
        
        using (TemporaryFile oTempOutputFile = new TemporaryFile())
        {
            try
            {
                String sXSLTProcArguments = "-o \"" + oTempOutputFile.FilePath + "\" \"" + oJob.ContentTemplate + "\" \"" + oTempInputFile.FilePath + "\"";
        
                Process oProcess = new Process();
                oProcess.StartInfo.UseShellExecute = false;
                oProcess.StartInfo.FileName = oJob.XSLTParser;
                oProcess.StartInfo.Arguments = sXSLTProcArguments;
                oProcess.StartInfo.RedirectStandardOutput = true;
                oProcess.StartInfo.RedirectStandardError = true;
                oProcess.StartInfo.CreateNoWindow = true;
                oProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                oProcess.Start();
                oProcess.WaitForExit(5000);
                if (File.Exists(oTempOutputFile.FilePath))
                {
                    using (StreamReader oReader = new StreamReader(oTempOutputFile.FilePath))
                    {
                        String sHTML = oReader.ReadToEnd();
        
                        if (sHTML.Length == 0)
                        {
                            Logger.Write(new DebugLogEntry("No HTML content was generated"));
                        }
                        else
                        {
                            //Do something with sHTML
                        }
                    }
                }
                else
                {
                    Logger.Write(new GeneralLogEntry("Failed to transform content for " + sDocumentID));
                }
            }
            catch (Exception e)
            {
                Logger.Write(new GeneralLogEntry("Exception thrown when transforming content for " + sDocumentID));
                Logger.Write(new DebugLogEntry(e.Message));
                Logger.Write(new DebugLogEntry(e.StackTrace));
            }
        }
    }    
