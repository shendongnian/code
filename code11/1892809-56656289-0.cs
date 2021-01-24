    var rowIndex =0;
    forech (var row in excelrows){
    DataRow dtRow= null;
    var cellIndex = 0;
    foreach (ExcelReportCell cell in row){
    if (rowIndex ==0) // generate the columns
    {
    dt.Columns.Add(new ColumnData(cell.GetText().ToString()));
    }else { // the columns has already been generated then generate the row
     dtRow = dtRow?? dt.NewRow();
     dtRow[cellIndex] = cell.GetText(); 
     }
    cellIndex++;
    }
    if (dtRow != null)
      dt.Rows.Add(dtRow);
    
    rowIndex ++;
    }
