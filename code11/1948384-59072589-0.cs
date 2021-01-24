                    ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                    ExcelWorksheet excelWorksheet = excelWorkBook.Worksheets[2];
    
                    
                    
                    ExcelRichTextCollection formatCollection = excelWorksheet.Cells[3, 2].RichText;
                    ExcelRichText format1 = formatCollection.Add("Red");
                    format1.Bold = true;
                    format1.Color = System.Drawing.Color.Red;
                    format1.Italic = true;
    
                    ExcelRichText format2 = formatCollection.Add("Blue");
                    format2.Bold = true;
                    format2.Color = System.Drawing.Color.Blue;
                    format2.Italic = false;
    
                   
    
                    excelPackage.Save();
