    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection; 
    
    
    namespace MergeWorkBooks
    {
        class Program
        {
            static void Main(string[] args)
            {
                Excel.Application app = new Excel.Application();
                
                app.Visible = true;
                app.Workbooks.Add("");
                app.Workbooks.Add(@"c:\MyWork\WorkBook1.xls");
                app.Workbooks.Add(@"c:\MyWork\WorkBook2.xls");
    
    
                for (int i = 2; i <= app.Workbooks.Count; i++)
                {
                    int count = app.Workbooks[i].Worksheets.Count;
    
                    app.Workbooks[i].Activate();
                    for (int j=1; j <= count; j++)
                    {
                        Excel._Worksheet ws = (Excel._Worksheet)app.Workbooks[i].Worksheets[j];
                        ws.Select(Type.Missing);
                        ws.Cells.Select();
    
                        Excel.Range sel = (Excel.Range)app.Selection;
                        sel.Copy(Type.Missing);
    
                        Excel._Worksheet sheet = (Excel._Worksheet)app.Workbooks[1].Worksheets.Add(
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing
                            );
    
                        sheet.Paste(Type.Missing, Type.Missing);
    
                    }
    
    
                }
    
            }
        }
    }
