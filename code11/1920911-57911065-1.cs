    public class WordPrintTask  
    {  
     private static object locker = new Object();  
     public WordPrintTask() { }  
     public void PrintWord()  
     {  
       try  
       {  
         // Kill opened word instances.  
         if (KillProcess("WINWORD"))  
         {  
           // Thread safe.  
           lock (locker)  
           {  
             string fileName = "D:\\PrinterDocs\\TEST.docx";  
             string printerName = "\\\\10.0.0.89\\PRINTER1020";  
             if (File.Exists(fileName))  
             {  
               Application _application = new Application();  
               _application.Application.ActivePrinter = printerName;  
               object oSourceFilePath = (object)fileName;  
               object docType = WdDocumentType.wdTypeDocument;  
               object oFalse = (object)false;  
               object oMissing = System.Reflection.Missing.Value;  
               Document _document = _application.Documents.Open(ref oSourceFilePath,  
                                  ref docType,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing,  
                                  ref oMissing);  
               // Print  
               _application.PrintOut(ref oFalse, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,  
                                 ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,  
                                 ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);  
               object saveOptions = WdSaveOptions.wdDoNotSaveChanges;  
               _document.Close(ref oFalse, ref oMissing, ref oMissing);  
               if (_application != null)  
               {  
                 object oSave = false;  
                 Object oMiss = System.Reflection.Missing.Value;  
                 _application.Quit(ref oSave, ref oMiss, ref oMissing);  
                 _application = null;  
               }  
               // Delete the file once it is printed  
               File.Delete(fileName);  
             }  
           }  
         }  
       }  
       catch (Exception ex)  
       {  
         KillProcess("WINWORD");  
       }  
       finally  
       {  
       }  
     }  
     private static bool KillProcess(string name)  
     {  
       foreach (Process clsProcess in Process.GetProcesses().Where(p => p.ProcessName.Contains(name)))  
       {  
         if (Process.GetCurrentProcess().Id == clsProcess.Id)  
           continue;  
         if (clsProcess.ProcessName.Contains(name))  
         {  
           clsProcess.Kill();  
           return true;  
         }  
       }  
       return true;  
     }  
    }
