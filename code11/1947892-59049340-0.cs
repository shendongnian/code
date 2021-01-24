    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ViewState["EmployeeDetails"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["EmployeeDetails"];
            dtCurrentTable.Rows.RemoveAt(e.RowIndex);
            ViewState["EmployeeDetails"] = dtCurrentTable;
            GridView1.EditIndex = -1;
            GridView1.DataBind();
            GridView1.DataSource = dtCurrentTable;
        }
    }
