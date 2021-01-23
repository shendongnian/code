    protected void gvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField lbl = (HiddenField)e.Row.FindControl("hdfAstID");
                    e.Row.Attributes.Add("onclick", "addToTextBox('" + lbl.Value + "')");
                }
    
            }
