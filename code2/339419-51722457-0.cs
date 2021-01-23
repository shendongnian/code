    //message box before deletion
    protected void grdEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (DataControlFieldCell cell in e.Row.Cells)
            {
                foreach (Control control in cell.Controls)
                {
                    LinkButton button = control as LinkButton;
                    if (button != null && button.CommandName == "Delete")
                        button.OnClientClick = "if (!confirm('Are you sure " +
                               "you want to delete this record?')) return false;";
                }
            }
        }
    }
    //deletion
    protected void grdEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        conn.Open();
        int empid = Convert.ToInt32(((Label)grdEmployee.Rows[e.RowIndex].Cells[0].FindControl("lblIdBind")).Text);
        SqlCommand cmdDelete = new SqlCommand("Delete from employee_details where id=" + empid, conn);
        cmdDelete.ExecuteNonQuery();
        conn.Close();
        grdEmployee_refreshdata();
    }
