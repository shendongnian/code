    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            GridViewRow selected = gv.Rows[Convert.ToInt32(e.CommandArgument)];
            List<ThatClass> cList = new List<ThatClass>();
            cList.Add(new ThatClass(selected.Cells[0].Text, selected.Cells[1].Text));
            dv.DataSource = cList;
            dv.DataBind();
        }
    }
