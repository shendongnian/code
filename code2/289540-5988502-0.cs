     protected void gridVariables_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string control = ((DropDownList)gridVariables.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue;
            gridVariables.EditIndex = -1;
            this.gridVariables_DataBind(control, e.RowIndex);
        }
    private void gridVariables_DataBind(string control, int index)
        {
            DataTable dt = (DataTable)Session["variableTable"]; //features a DataTable with the Contents of the Gridview
            dt.Rows[index]["ControlType"] = control;
            gridVariables.DataSource = dt;
            gridVariables.DataBind();
        }
