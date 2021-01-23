    System.Web.UI.WebControls.GridView() test = new System.Web.UI.WebControls.GridView();
    for (int i = 0; i < grid.Rows.Count; i++)
    {
        test.Rows[i].Cells[<yer column index>].Text = "=/"" + test.Rows[i].Cells[<yer column index>].Text + "/"";
    }
