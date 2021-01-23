    int index = 0;
    bool hidden = false;
    protected void gvEmployees_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
            if(hidden)
            {
                 e.Row.Cells[index].Visible =  false;
                 return;
            }
            string name = "First Name";// Column name supposed to hide
             for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text.ToLower().Trim() == name.ToLower().Trim())
                {
                    e.Row.Cells[i].Visible = false;
                    hidden = true;
                    index = i;
                    break;
                }
    }
