     for (int z=1;z<30;z++)
            {
                Microsoft.Office.Interop.Excel.Range row = xlWorkSheet.Rows[z];
                row.EntireRow.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Azure); ;
            }
