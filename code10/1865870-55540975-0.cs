using System;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
namespace TestCsCom
{
    class Program
    {
        static void Main(string[] args)
        {
            // NOTE: Don't call Excel objects in here... 
            //       Debugger would keep alive until end, preventing GC cleanup
            // Call a separate function that talks to Excel
            DoTheWork();
            // Now let the GC clean up (repeat, until no more)
            do
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            while (Marshal.AreComObjectsAvailableForCleanup());
        }
        static void DoTheWork()
        {
            Application app = new Application();
            Workbook book = app.Workbooks.Add();
            Worksheet worksheet = book.Worksheets["Sheet1"];
            app.Visible = true;
            for (int i = 1; i <= 10; i++) {
                worksheet.Cells.Range["A" + i].Value = "Hello";
            }
            book.Save();
            book.Close();
            app.Quit();
            // NOTE: No calls the Marshal.ReleaseComObject() are ever needed
        }
    }
}
