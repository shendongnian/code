    `public void ReadExcel(string path){
     try
     {
     System.Data.DataTable dt = new System.Data.DataTable();
     Microsoft.Office.Interop.Excel.Application xlApp = new 
     Microsoft.Office.Interop.Excel.Application();
     Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
     Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
     Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
     int rowCount = xlRange.Rows.Count;
     for (int r = 2; r <= rowCount; r++)
     INSERT INTO mytable (ID,NAME,CLASS)VALUES (dr[c - 1] = xlRange.Cells[r, c].Text, 
     xlRange.Cells[r,c+1].Text, xlRange.Cells[r,c+2].Text);
     }
     }
     }catch(Exception ex){throw ex;}
     `
