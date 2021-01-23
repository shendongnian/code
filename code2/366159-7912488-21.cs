    List<int> indexes = new List<int>();
    bool hidden = false;
    List<string> names = new List<string>();
    protected void gvEmployees_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if(hidden)
        {
             foreach(int index in indexes)
             {
                 e.Row.Cells[index].Visible =  false;
             }
        }
        // start - Column names supposed to hide
        // Building the list of column names to be hidden.
        names.Add("First Name");
        names.Add("Last Name");
        names.Add("Address");
        names.Add("ID");
        // end - Column names supposed to hide
        for (int i = 0; i < e.Row.Cells.Count; i++)
        {
            if (names.Contains(e.Row.Cells[i].Text.ToLower().Trim())
            {
                e.Row.Cells[i].Visible = false;
                hidden = true;
                indexes.Add(i);
            }
        }
    }
