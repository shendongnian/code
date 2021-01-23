       protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            b.Visible = false;
            GridViewRow r = (GridViewRow)b.NamingContainer;
            ((DropDownList)(GridView1.Rows[r.RowIndex].Cells[0].FindControl("DropDownList1"))).Visible = true;
        }
