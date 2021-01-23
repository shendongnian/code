                Excel.Worksheet lastSheet = Application.ActiveSheet;
                Excel.Workbook wb = Application.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                for (int i = this.Worksheets.Count; i >= 1; i--)
                {
                    Excel.Worksheet source = this.Worksheets[i];
                    source.Activate();
                    Application.Cells.Select();
                    Application.Selection.Copy();
                    Excel.Worksheet sheet = wb.Worksheets.Add();
                    sheet.Activate();
                    Application.Selection.PasteSpecial(Excel.XlPasteType.xlPasteValues);
                    Application.Selection.PasteSpecial(Excel.XlPasteType.xlPasteFormats);
                    sheet.Name = source.Name;
                    sheet.Range["A1"].Select();
                    Clipboard.Clear();
                }
                lastSheet.Activate();
                lastSheet.Range["A1"].Select();
                wb.SaveAs(fileName);
                wb.Close();
