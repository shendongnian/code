     protected void btnRemove_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string bid = btn.ID;       
            Table tl = (Table)panel.FindControl("tal");
            for (int i = 1; i < tbl.Rows.Count; i++)
            {
                TableRow row = (TableRow)tl.Rows[i];
                string id = "lnk" + (i-1).ToString();
                if (bid == row.Cells[2].FindControl(id).ID)
                {
                    tbl.Rows.Remove(row);
                }
            }
        }
