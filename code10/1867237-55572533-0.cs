    protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ddl3.Items.Clear();
            s = "SELECT subject FROM subjects WHERE branch='" + ddl1.SelectedItem.Value + "' AND sem='" + ddl2.SelectedItem.Value + "'";
            ds = dc.getdata(s);
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                ddl3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
