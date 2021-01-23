    public IEnumerable<string> Get(string tableName, string parameter) {
      var ds = objDatabase.ByText("Select distinct " + parameter + 
        " from " + tableName + " where Del_Status = 'Available'");
      return ds.Tables[0].Rows.Select(row => row.ItemArray[0].ToString());
    }
