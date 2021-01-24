     protected void ResultGrid_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Determine the RowIndex of the Row whose Button was clicked.
                //int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
                String key = ResultGrid.SelectedDataKey.Value.ToString();
                //Get the value of column from the DataKeys using the RowIndex.
                //int id = Convert.ToInt32(ResultGrid.DataKeys[rowIndex].Values[01]);
                //  Response.Write("IM_RAA_657x_Date.aspx?Day=" + ResultGrid.SelectedDataKey.Value(0) + "&BusinessCategory=" + ResultGrid.SelectedDataKey.Values(1).ToString())
            }
