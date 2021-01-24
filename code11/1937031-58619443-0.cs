    public bool ExtractExcelToDB(int activityId, string tableName, string fileName) {
      using(SqlConnection connection = new SqlConnection(GetConnectionStringBulk())) {
        SqlTransaction tran = null;
        try {
          connection.Open();
          tran = connection.BeginTransaction();
    
          var path = GetPath(activityId);
          path = Path.Combine(path, fileName);
          using(FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read)) {
            using(IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream)) {
              DataSet result = excelReader.AsDataSet();
              DataTable dt = result.Tables["sheet"];
              DataTable newDt = dt.Select().Skip(1).Take(dt.Rows.Count).CopyToDataTable();
              using(SqlBulkCopy sqlBulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, tran)) {
                sqlBulk.DestinationTableName = tableName;
    
                var bacth = newDt.Rows.Count / 10;
                for (int i = 0; i <= bacth; i++) {
                  var rows = newDt.Select().Skip(i * 10).Take(10).ToArray();
                  sqlBulk.WriteToServer(rows);
                }
              }
    
              tran.Commit();
    
            }
            return true;
          }
    
    
        } catch (Exception ex) {
    
    
          db.ExceptionErrors.Add(new ExceptionError {
            Value = ex.Message,
              Date = DateTime.Now
          });
          db.SaveChanges();
    
          if (tran != null) {
            tran.Rollback();
          }
    
          return false;
        }
      }
    }
