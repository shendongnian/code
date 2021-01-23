    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlCommand comm = new SqlCommand();
        StringBuilder sb = new StringBuilder("INSET INTO [Table] ");
        string template = " SELECT @{0} UNION ALL ";
        foreach(GridViewRow gvr in GridView1.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                string value = ((DropDownList)gvr.FindControl("didDdl")).SelectedValue;
                sb.AppendFormat(template, value);
                comm.Parameters.Add(new SqlParameter("@" + value, value));
            }
        }
        comm.CommandText = sb.ToString()
    }
