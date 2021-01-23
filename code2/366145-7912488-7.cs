    bool hidden = false;
    protected void gvEmployees_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
            if(hidden) // return if column was already hidden for once.
                return;
            string name = "First Name";// Column name supposed to hide
             for (int i = 0; i < e.Rows.Cells.Count; i++)
            {
                if (e.Cells[i].Text.ToLower().Trim() == name.ToLower().Trim())
                {
                    e.Cells[i].Visible = false;
                    hidden = true;
                }
    }
