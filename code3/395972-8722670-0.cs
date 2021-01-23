    protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            GridViewRow r = (GridViewRow)b.NamingContainer;
            ((TextBox)(GridView1.Rows[r.RowIndex].Cells[0].FindControl("TextBox1"))).Visible = false;
        }
