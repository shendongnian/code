    table = new DataTable();
    table.Columns.Add("Name");
    table.Columns.Add("Type");
    table.Columns.Add("Status");
    table.Columns.Add("Date Created");
    table.Columns.Add("Action");
    var db = new DbDataContext();
    var users = (from u in db.users
                 where u.Contains(textBoxSearch.Text)
                 select u).ToList();
    foreach(var user in users)
    {
         MessageBox.Show(user.uName + user.uType + user.uStatus);
                row = table.NewRow();
                row["Name"] = user.uName;
                row["Type"] = duser.uType;
                row["Status"] = user.uStatus;
                row["Date Created"] = user.uDate.ToShortDateString();
                table.Rows.Add(row);
    }
    UsersView.DataSource = table;
