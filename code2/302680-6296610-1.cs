    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<string> lst = new List<string>();
        foreach(GridViewRow gvr in GridView1.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                lst.Add(((DropDownList)gvr.FindControl("didDdl")).SelectedValue);
            }
        }
    }
