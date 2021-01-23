     public Excel.Application PrepareForExport(System.Data.DataSet ds,string[] sheet)
        {
                object missing = System.Reflection.Missing.Value;
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Workbooks.Add(missing);
           
                DataTable dt1 = new DataTable();
                dt1 = ds.Tables[0];
                DataTable dt2 = new DataTable();
                dt2 = ds.Tables[1];
                Excel.Worksheet newWorksheet;
                newWorksheet = (Excel.Worksheet)excel.Worksheets.Add(missing, missing, missing, missing);
                newWorksheet.Name ="Name of data sheet";
                
	//  for first datatable dt1..
                int iCol1 = 0;
                foreach (DataColumn c in dt1.Columns)
                {
                    iCol1++;
                    excel.Cells[1, iCol1] = c.ColumnName;
                }
                int iRow1 = 0;
                foreach (DataRow r in dt1.Rows)
                {
                    iRow1++;
                    for (int i = 1; i < dt1.Columns.Count + 1; i++)
                    {
                        if (iRow1 == 1)
                        {
                            // Add the header the first time through 
                            excel.Cells[iRow1, i] = dt1.Columns[i - 1].ColumnName;
                        }
                             
                        excel.Cells[iRow1 + 1, i] = r[i - 1].ToString();
                    }
                }
     
       //  for  second datatable dt2..
                int iCol2 = 0;
                foreach (DataColumn c in dt2.Columns)
                {
                    iCol2++;
                    excel.Cells[1, iCol] = c.ColumnName;
                }
                int iRow2 = 0;
                foreach (DataRow r in dt2.Rows)
                {
                    iRow2++;
                    for (int i = 1; i < dt2.Columns.Count + 1; i++)
                    {
                        if (iRow2 == 1)
                        {
                            // Add the header the first time through 
                            excel.Cells[iRow2, i] = dt2.Columns[i - 1].ColumnName;
                        }
                             
                        excel.Cells[iRow2 + 1, i] = r[i - 1].ToString();
                    }
                }
              
           
            return excel;
        }
