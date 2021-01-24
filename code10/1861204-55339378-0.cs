    protected void gvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    TextBox fitlerDate = (TextBox)e.Row.FindControl("fitlerDate");
                    if (fitlerDate != null)
                    {
                        fitlerDate.Text = ViewState["fitlerDate"].ToString();
                    }
                }            
            }
