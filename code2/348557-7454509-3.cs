    public List<string> get(string tableName, string parameter) {
            var valuesForDDL = new List<Whatever>();
            var ds = objDatabase.ByText("Select distinct " + parameter + " from " + tableName + " where Del_Status = 'Available'");
            foreach (DataRow row in ds.Tables[0].Rows) {
                valuesForDDL.Add(row.ItemArray[0].ToString());
            }
            return valuesForDDL;
    }
