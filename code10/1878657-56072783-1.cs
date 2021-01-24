        [HttpPost]
        public ActionResult ImportExcel(HttpPostedFileBase postedFile)
         {
          try
            {
              string filePath = string.Empty;
              if (postedFile != null)
              {
                //Save File
                string path = Server.MapPath("~/ExcelUpload/");
                if (!Directory.Exists(path))
                {
                   Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);
                //End
                string conString = string.Empty;
                switch (extension)
                {
                 case ".xls": //Excel 97-03.
                      conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                      break;
                 case ".xlsx": //Excel 07 and above.
                      conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
                }
                //Add Excel Data To Datatable
                DataTable dt = new DataTable();               
                conString = string.Format(conString, filePath);
                //Get Actual Data for Excel
                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                   using (OleDbCommand cmdExcel = new OleDbCommand())
                   {
                      using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                       {
                         cmdExcel.Connection = connExcel;
                         //Get the name of First Sheet.
                         connExcel.Open();
                         DataTable dtExcelSchema;
                         dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                         string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                         connExcel.Close();
                         //Read Data from First Sheet.
                         connExcel.Open();
                         cmdExcel.CommandText = "SELECT * From [" + sheetName + "] Where Name IS NOT NULL AND NOT Name=''";
                         odaExcel.SelectCommand = cmdExcel;
                         odaExcel.Fill(dt);
                         connExcel.Close();
                        }
                     }
                  }                   
                 //Insert Call Dispositions table bulk upload
                 conString = ConfigurationManager.ConnectionStrings["exportDataToExcel"].ConnectionString;
                 using (SqlConnection con = new SqlConnection(conString))
                 {
                  using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                       TempData["TotalInsertCount"] = dt.Rows.Count;
                       foreach (DataColumn col in dt.Columns)
                                col.ColumnName = col.ColumnName.Trim();
        
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.CallDispositions";
                        //[OPTIONAL]: Map the Excel columns with that of the database table                       
                         sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                         sqlBulkCopy.ColumnMappings.Add("TAT", "TAT");
                         sqlBulkCopy.ColumnMappings.Add("Discription", "Discription");
                         con.Open();
                         sqlBulkCopy.WriteToServer(dt); //
                         con.Close();
                     }
                  }
              //End
            }
          }
         catch (Exception ex)
         {
        
         }
         return RedirectToAction("List"); }
