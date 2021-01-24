     ////In your case, get it from SQL and remove all StringBuilder and html table code
                `DataTable dt = GetData();
                 GvServer.DataSource = dt;
                 GvServer.DataBind();
        DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Server");
            dt.Columns.Add("Status");
            DataRow row = dt.NewRow();
            row["Server"] = "Server 1";
            row["Status"] = "Offline";
            dt.Rows.Add(row);
            DataRow row2 = dt.NewRow();
            row2["Server"] = "Server 2";
            row2["Status"] = "Online";
            dt.Rows.Add(row2);
            DataRow row3 = dt.NewRow();
            row3["Server"] = "Server 3";
            row3["Status"] = "Online";
            dt.Rows.Add(row3);
            DataRow row4 = dt.NewRow();
            row4["Server"] = "Server 4";
            row4["Status"] = "Offline";
            dt.Rows.Add(row4);
            return dt;
        }
        protected void GvServer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (Convert.ToString(e.Row.Cells[1].Text) == "Online")
            {
                e.Row.BackColor = System.Drawing.Color.Green;
            }
            else if (Convert.ToString(e.Row.Cells[1].Text) == "Offline")
            {
                e.Row.BackColor = System.Drawing.Color.Red;
            }
