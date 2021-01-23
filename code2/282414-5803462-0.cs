    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e){
    
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink link = new HyperLink();
                link.Text = e.Row.Cells[0].Text;
                link.NavigateUrl = "Goal_AssignmentPage.aspx?" + link.Text; // change in your code
                e.Row.Cells[0].Controls.Add(link);
            }
        }
