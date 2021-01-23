    protected void GridView_AA_RowCreated(object sender, GridViewRowEventArgs e)
    {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    LinkButton lb_pname = (LinkButton)(e.Row.Cells[2].Controls[0]);
                    lb_pname.Text = "Period Nameะ";
                    e.Row.Cells[2].Controls.Add(lb_pname);
                }
    }
