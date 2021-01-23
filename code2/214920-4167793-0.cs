    public void SetupDataGridView()
    {
                table = new DataTable();
                bcol = new DataGridViewButtonColumn();
                bcol.HeaderText = "Action ";
                bcol.Text = "Delete";
                bcol.Name = "deleteUserButton";
                bcol.UseColumnTextForButtonValue = true;                
    
                table.Columns.Add("Name");
                table.Columns.Add("Type");
                table.Columns.Add("Status");
                table.Columns.Add("Date Created");
    
                UsersView.DataSource = table;
                UsersView.AllowUserToAddRows = false;//To remove extra row at the end
                UsersView.Columns.Add(bcol);
    }
    
    public void PopulateDataGridView()
    {
                
                for (int i = 0; i < userAction.UserName.ToArray().Length; i++)
                {
                    row = table.NewRow();
                    asc.Add(userAction.UserName[i]);
                    row["Name"] = userAction.UserName[i];
                    row["Type"] = userAction.UserType[i];
                    row["Status"] = userAction.UserStatus[i];
                    row["Date Created"] = userAction.DateCrea[i];
                    table.Rows.Add(row);
                }
    
    }
