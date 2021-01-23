    using System;
    using System.Text;
    using Microsoft.Office.Interop.Excel;
    namespace ExportExcelFormulas
    {
        static class ExcelAccess
        {
            public static void ExportFormulasSimple(string filePath)
            {
                var app = new Application();
                var workbook = app.Workbooks.Open(filePath);
                var sCount = workbook.Sheets.Count;
                var sb = new StringBuilder();
                for (int s = 1; s <= sCount; s++)
                {
                    var sheet = workbook.Sheets[s];
                    var range = sheet.UsedRange;
                    var f = range.Formula;
                    var cCount = range.Columns.Count;
                    var rCount = range.Rows.Count;
                    for (int r = 1; r <= rCount; r++)
                    {
                        for (int c = 1; c <= cCount; c++)
                        {
                            var id = ColumnIndexToColumnLetter(c) + "" + r + ": ";
                            var val = f[r, c];
                            if (!string.IsNullOrEmpty(val))
                            {
                                sb.AppendLine(id + val);
                                Console.WriteLine(id + val);
                            }
                        }
                    }
                }
                var text = sb.ToString();
            }
            // Based on https://www.add-in-express.com/creating-addins-blog/2013/11/13/convert-excel-column-number-to-name/
            public static string ColumnIndexToColumnLetter(int i)
            {
                var l = "";
                var mod = 0;
                while (i > 0)
                {
                    mod = (i - 1) % 26;
                    l = (char)(65 + mod) + l;
                    i = (int)((i - mod) / 26);
                }
                return l;
            }
        }
    }
