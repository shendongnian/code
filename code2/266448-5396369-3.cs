    private void AddDataToTable(string username,string firstname,string lastname,DataTable myTable)
    {
    DataRow row;
    
    row = myTable.NewRow();
    
    row["id"] = Guid.NewGuid().ToString();
    row["username"] = username;
    row["firstname"] = firstname;
    row["lastname"] = lastname;
    
    myTable.Rows.Add(row);
    }
