    protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                DropDownList ddlList = (DropDownList)e.Row.FindControl("Name_of_DPList");
                int i=e.Row.RowIndex;
                DataTable dtTable = (DataTable)ViewState["dtPurchaseOrder"];
                string str = dtTable.Rows[i]["Name_Of_column"].ToString();//Name of the column in data source that stores the status.
                ddlList.items.FindByText(str).Selected=true;
            }
        }
        
