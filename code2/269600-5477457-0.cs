    while (myDataReader.Read())
    {
         DataRow drNew = DataTable.NewRow();
         drNew["ID"] = myDataReader["ID#"].ToString().Trim();
         drNew["Name"] = myDataReader["NAME"].ToString().Trim());
         ...
         DataRow[] badRow = DataTable.Select(
              "ID='" + drNew["ID"] + "' and Name='" + drNew["Name"] + "'");
         if(badRow.Length >0)
             DataTable.Rows.Remove(badRow[0]);
    }
