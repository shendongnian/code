      using Excel;
      var importFile = Request.Files["files"];
      if (importFile.ContentLength == 0)
      {
           ViewBag.errorFileMessage = "Please select file";
           return View();
      }
      Stream stream = importFile.InputStream;
      IExcelDataReader reader = null;
      reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
      reader.IsFirstRowAsColumnNames = true;
      DataSet result = reader.AsDataSet();
      DataTable dataRecords = new DataTable();
      //You can also remove empty rows 
      if (result.Tables.Count > 0)
      {
          dataRecords = result.Tables[0];
          for (int i = dataRecords.Rows.Count - 1; i >= 0; i--)
          {
              if (dataRecords.Rows[i][0] == DBNull.Value)
              {
                  dataRecords.Rows[i].Delete();
              }
              dataRecords.AcceptChanges();
          }
       }
       if (dataRecords.Rows.Count > 0)
       {
            List<MyExcelListModel> reqData = new List<MyExcelListModel>();
            foreach (DataRow row in dataRecords.Rows)
            {
                MyExcelModel exceldata = new MyExcelModel();
                exceldata.Name= row[0].ToString();
                //Add according to your requirements
                reqData.Add(exceldata);
            }     
       } 
     
           
