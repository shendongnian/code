    for (int iRow = 10; iRow <= iRows; iRow++)
     {
       for (int iCol = 1; iCol <= iCols; iCol++)
       {
          xlRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[iRow, iCol];
          Console.WriteLine(xlRange.Text); // From here do as per you required and insert the required data to the data base. 
       }
     }
