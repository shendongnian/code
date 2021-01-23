    protected void btnDeleteChecked_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gridOrders.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("cbSelector");
            if ((null != cb) && cb.Checked)
            {
                uint id = Convert.ToUInt32(gridOrders.DataKeys[row.RowIndex].Value);
                gInvoiceDB.DeleteInvoice(id, true);
            }
        }
    }
