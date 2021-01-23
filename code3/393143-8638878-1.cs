    private void _insertData() {
      using (var c = new SqlConnection(CS)) {
        c.Open();
        using (var trans = c.BeginTransaction()) {
          try {
            using (var bc = new SqlBulkCopy(
              c, SqlBulkCopyOptions.TableLock, trans))
            {
              bc.DestinationTableName = "dbo.Insert_TestResults";
              bc.WriteToServer(dt);
            }
            trans.Commit();
          }
          catch (Exception e) {
            trans.Rollback();
            throw;
          }
        }
      }
    }  
