    private void BindRolesToList()
    {
        string[] roles = Roles.GetAllRoles();
        //make a table for the data, with two columns, RoleName and RoleCount
        DataTable data = new DataTable();
        DataColumn column;
        column = New DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "RoleName";
        table.Columns.Add(column);
        column = New DataColumn();
        column.DataType = System.Type.GetType("System.Int32");
        column.ColumnName = "RoleCount";
        table.Columns.Add(column);
        // Populate the data
        DataRow row;
        for (int i = 0; i<roles.Length; i++ )
        {
             row = data.NewRow();
             row["RoleName"] = roles[i];
             row["RoleCount"] = Roles.GetUsersInRole(roles[i]).Count();
             data.Rows.Add(row);
        }
        RoleList.DataSource = data;
        RoleList.DataBind();    
    }
    private void LinkButton_Command(Object sender, CommandEventArgs e) 
    {
        string RoleName = e.CommandArgument;
        //whatever code deletes the role, e.g.
        //  Roles.DeleteRole(RoleName);
        BindRolesToList();
       
    }
