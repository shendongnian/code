            Microsoft.Office.Interop.Excel.Application appExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
            Microsoft.Office.Interop.Excel.Workbook srcBook = appExcel.Workbooks.Open(@"c:\tmp\test.xls",
                       Missing.Value, Missing.Value, Missing.Value,
                       Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                       Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                       Missing.Value, Missing.Value, Missing.Value);
            Microsoft.Office.Interop.Excel.Workbook destBook = appExcel.Workbooks.Add(Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet srcSheet = (Microsoft.Office.Interop.Excel.Worksheet)srcBook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range usedRange = srcSheet.UsedRange;
            usedRange.Replace("=", "X_X_X_X_X_X", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            srcSheet.Copy(destBook.Worksheets[1], Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet destSheet = (Microsoft.Office.Interop.Excel.Worksheet)destBook.Worksheets[1];
            usedRange.Replace("X_X_X_X_X_X", "=", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            usedRange = destSheet.UsedRange;
            usedRange.Replace("X_X_X_X_X_X", "=", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
