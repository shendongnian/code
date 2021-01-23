    List<string> dbItems = new List<string>();
    while(myReader.Read())
    {
       dbItems.Add(Convert.ToString(myReader["ColumnName1"]));
       dbItems.Add(Convert.ToString(myReader["ColumnName2"]));
       ...
    }
