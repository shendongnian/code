    foreach (DataRow row in GlobalClass.NAVdataTable.Rows)
      {
        GlobalClass.AddToDbCommand(ref dBCommand, row["FieldName"].ToString(), row["Value"].ToString());
        connection.Open();
        SqlDb.ExecuteNonQuery(dBCommand);
        connection.Close();
        dBCommand.Parameters.Clear();
      }
