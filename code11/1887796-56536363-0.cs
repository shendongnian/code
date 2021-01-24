        public void WriteExcelWithNPOI(DataTable dt, String extension,string MSANAme,string CheckValue)
        {
    
            IWorkbook workbook;
    
            if (extension == "xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (extension == "xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported");
            }
    
            ISheet sheet1 = workbook.CreateSheet("Sheet 1");
            //make a header row
            IRow row1 = sheet1.CreateRow(0);
            var cellStyleForLocked = workbook.CreateCellStyle(); //create the style in the beginning itself
            cellStyleForLocked.IsLocked = true;
    
            for (int j = 0; j < dt.Columns.Count; j++)
            {
    
                ICell cell = row1.CreateCell(j);
                String columnName = dt.Columns[j].ToString();
                cell.SetCellValue(columnName);
            }
    
            //loops through data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
    
                    ICell cell = row.CreateCell(j);
                    String columnName = dt.Columns[j].ToString();
    
                    if(j < 6) //set the locked style only for first 6 columns.
                        cell.CellStyle = cellStyleForLocked;
    
                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                }
            }
    
            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                if (extension == "xlsx") //xlsx file format
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}" + MSANAme + CheckValue+ ".xlsx"));
    
                    Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename="+ MSANAme + CheckValue + ".xls"));
                    Response.BinaryWrite(exportData.GetBuffer());
                }
                Response.End();
            }
        }
