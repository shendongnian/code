        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView g2 = (GridView)sender;
            g2.EditIndex = e.NewEditIndex;
    
            GridViewRow gvCustomerRow = g2.NamingContainer as GridViewRow;
            int customerId = (int)g1.DataKeys[gvCustomerRow.RowIndex].Value;
    
            sql = @String.Format(" SELECT * FROM `doTable` ");
            sql += String.Format(" WHERE sID IN ('{0}') ", customerId);
    
            g2.DataSource = GetData(sql);
            g2.DataBind();
        }
