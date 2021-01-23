      protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = 0;
        string strLine = string.Empty;
        string[] lines = null;
        if (e.CommandName == "Image")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            Label l = (Label)GridView1.Rows[row.RowIndex].Cells[1].FindControl("Label1");
            id = Convert.ToInt16(l.Text);
            string selectSQL = "Select File_Data from tblachmaster WHERE Id IN (" + id + ")";
            MySqlCommand cmd1 = new MySqlCommand(selectSQL);
            cmd1.Parameters.Add("@_id", SqlDbType.Int).Value = id;
            DataTable dt1 = GetData1(cmd1);
            if (dt1 != null)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    Byte[] bytes = (Byte[])dt1.Rows[i]["File_Data"];
                    string text = Encoding.UTF8.GetString(bytes);
                    lines = Regex.Split(text, "\r\n");
                    strLine = convertArrayToString(lines);
                }
            }
            DataTable table = new DataTable();
            table.Columns.Add("RecordTypeCode", typeof(string));
            table.Columns.Add("Content", typeof(string));
            foreach (string strcontent in lines)
            {
                if (strcontent != string.Empty)
                    table.Rows.Add(rectype[(strcontent.Substring(0, 1))], strcontent);
            }
            dynamicGridView.DataSource = table;
            dynamicGridView.DataBind();
            popup.Show();
        }
    }
