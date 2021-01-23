    private void showemptygrid()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Date", typeof(string));
    
    
            for (int i = 0; i < 20; i++)  // add 20 empty rows
            {
                DataRow dr = table.NewRow();
                dr["ID"] = "";
                dr["Name"] = "";
                dr["Date"] = "";
                table.Rows.Add(dr);
            }
            grid_logs.DataSource = table;
            grid_logs.DataBind();
        }
