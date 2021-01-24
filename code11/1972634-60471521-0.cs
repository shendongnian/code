    using System;
    using System.IO;
    using excel = Microsoft.Office.Interop.Excel;
    
    namespace ExcelInterop {
        static class Program {
            // Create only one instance of excel.Application(). More instances create more Excel objects in Task Manager.
            static excel.Application ExcelApp { get; set; } = new excel.Application();
    
            [STAThread]
            static int Main() {
                try {
                    ExcelRunner excelRunner = new ExcelRunner(ExcelApp)
                    // do your Excel interop activities in your excelRunner class here
                    // excelRunner MUST be out-of-scope when the finally clause executes
                    excelRunner = null;  // not really necessary but kills the only reference to excelRunner 
                } catch (Exception e) {
                    // A catch block is required to ensure that the finally block excutes after an unhandled exception
                    // see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-finally
                    Console.WriteLine($"ExcelRunner terminated with unhandled Exception: '{e.Message}'");
                    return -1;
                } finally {
                    // this must not execute until all objects derived from 'ExcelApp' are out of scope
                    if (ExcelApp != null) {
                        ExcelApp.Quit();
                        ExcelApp = null;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                Console.WriteLine("ExcelRunner terminated normally");
                return 0;
            }
        }
    }
