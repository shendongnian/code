    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach(GridViewRow row in GridView1.Rows)
        {
            //Could also use (CheckBox)row.Cells[ColumnSelect].FindControl if you give the checkboxes IDs when generating them.
            CheckBox cb = (CheckBox)row.Cells[ColumnSelect].Controls[0];
            if (cb.Checked)
            {
                //Do something here.
            }
        }
    }
