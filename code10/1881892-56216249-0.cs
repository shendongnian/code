        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Menu", Type.GetType("System.String"));
            dt.Columns.Add("cost", Type.GetType("System.String"));
            // capture selected item value for 1st listbox 
            foreach (ListItem lst in ListBox1.Items)
            {
                if (lst.Selected)
                {
                    DataRow dr = dt.NewRow();
                    dr["Menu"] = lst.Text;
                    dt.Rows.Add(dr);
                }
            }
            // capture selected item value for 2nd listbox 
            foreach (ListItem lst in ListBox2.Items)
            {
                if (lst.Selected)
                {
                    DataRow dr = dt.NewRow();
                    dr["Menu"] = lst.Text;
                    dt.Rows.Add(dr);
                }
            }
            // finally display the data to gridview 
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
