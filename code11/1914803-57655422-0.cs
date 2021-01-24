       DataTable Contents = new DataTable();
       using (OleDbDataAdapter cmd = new OleDbDataAdapter("Select * from [" + firstSheetName + "]", excelConnection))
       {
         cmd.Fill(Contents);
         using (SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection))
         {
           sqlBulk.DestinationTableName = tableName;
           sqlBulk.WriteToServer(Contents);
          }
       }
