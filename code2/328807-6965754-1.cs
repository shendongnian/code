    void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            var control = e.Row.Cell[cellIndex].FindControl("ControlID");
            e.Row.Cells[1].Text = ((TypeOfControl)control).Text;
        }
    }
