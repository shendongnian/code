    public void CopyRows(excel.Workbook workbook, string sourceSheetName, string DestSheetName, int rowIndex)
            {
                excel.Worksheet sourceSheet = (excel.Worksheet)workbook.Sheets[sourceSheetName];
                excel.Range source = (excel.Range)sourceSheet.Range["A" + rowIndex.ToString(), Type.Missing].EntireRow;
    
                excel.Worksheet destSheet = (excel.Worksheet)workbook.Sheets[DestSheetName];
                excel.Range dest = (excel.Range)destSheet.Range["A" + rowIndex.ToString(), Type.Missing].EntireRow;
                source.Copy(dest);
    
                excel.Range newRow = (excel.Range)destSheet.Rows[rowIndex+1];
                newRow.Insert();
                workbook.Save();
            }
