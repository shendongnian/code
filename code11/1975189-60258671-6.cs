    int userID = 0;
    string[] columnNameParts;
    Result.GridViewDataTable = ds.Tables[3];
    for (int currCol = 1; currCol < Result.GridViewDataTable.Columns.Count; currCol++)
    {
        columnNameParts = Result.GridViewDataTable.Columns[currCol].ColumnName.Split(new string[] { "---" }, StringSplitOptions.RemoveEmptyEntries);
        userID = int.Parse(columnNameParts[columnNameParts.Length - 1]);
    
        string columnName = ds.Tables[2].Select("Id = " + userID)[0]["FirstName"].ToString()
            + " "
            + ds.Tables[2].Select("Id = " + userID)[0]["LastName"].ToString().Substring(0, 1);
        //index
        int n = 0;
        //Create new temporary columnName which will add to the Columns later 
        string tmpColumnName = columnName;
        //Check if column name is duplicate.
        while (Result.GridViewDataTable.Columns.Contains(tmpColumnName))
        {
            //Add 1 to index
            n++;
            //Create new name such as Matthew W1,Matthew W2,Daniel G1,Matthew W3,...
            tmpColumnName = columnName + n.ToString();
        }
        //Add new unique column name to Columns
        Result.GridViewDataTable.Columns[currCol].ColumnName = columnName;
    }
