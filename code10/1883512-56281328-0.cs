     {
                string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM AvSites", con);
                SqlDataAdapter dataadpter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable("AvSites");
                WriteExcelWithNPOI(datatable,"xls")  /* "xls" or "xlsx"
                MessageBox.Show("export data");
    
            }
    public void WriteExcelWithNPOI(DataTable dt, String extension)
          {           
              IWorkbook workbook;          
     
              if (extension == "xlsx") {
                  workbook = new XSSFWorkbook();                
              }
              else if (extension == "xls")
              {
                  workbook = new HSSFWorkbook();
              }
              else {
                  throw new Exception("This format is not supported");
              }
               
              ISheet sheet1 = workbook.CreateSheet("Sheet 1");
               
              //make a header row
              IRow row1 = sheet1.CreateRow(0);
     
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
                      Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "ContactNPOI.xlsx"));                   
                      Response.BinaryWrite(exportData.ToArray());             
                  }
                  else if (extension == "xls")  //xls file format
                  { 
                      Response.ContentType = "application/vnd.ms-excel";
                      Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "ContactNPOI.xls"));
                      Response.BinaryWrite(exportData.GetBuffer());
                  }   
                  Response.End();
              }
          }
