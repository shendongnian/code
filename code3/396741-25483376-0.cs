    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow rw in GridView1.Rows)
        {
            TextBox tx = (TextBox)rw.FindControl("txtHC");
            if (tx.Text == "Value")
                rw.Visible = false; 
            
        }
    }
